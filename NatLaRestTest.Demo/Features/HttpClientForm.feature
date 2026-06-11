Feature: HttpClient Form

Send HTTP requests with form content specified as key-value pairs in a data table.

Use the tests in here with a running instance of the NatLaRestTest.DemoWebApi project.

Background:
	Given SSL certificate validation is disabled
	And the base URL '$(demoApiBaseUrl)'

Scenario: POST form content using default step (POST method, default content type)
	When a request is made to '/form' with the following form content:
		| Key  | Value |
		| Name | John  |
		| Age  | 30    |
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp'
	Then the value of variable 'resp' matches the regex pattern '"Name":"John"'
	And the value of variable 'resp' matches the regex pattern '"Age":"30"'

Scenario: PUT form content with explicit HTTP method
	When a 'PUT' request is made to '/form' with the following form content:
		| Key    | Value  |
		| Status | active |
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp'
	Then the value of variable 'resp' matches the regex pattern '"Status":"active"'

Scenario: POST form content with explicit content type
	When a request is made to '/form' with content type 'application/x-www-form-urlencoded' and the following form content:
		| Key  | Value |
		| User | Admin |
		| Role | owner |
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp'
	Then the value of variable 'resp' matches the regex pattern '"User":"Admin"'
	And the value of variable 'resp' matches the regex pattern '"Role":"owner"'

Scenario: PUT form content with explicit HTTP method and content type
	When a 'PUT' request is made to '/form' with content type 'application/x-www-form-urlencoded' and the following form content:
		| Key  | Value  |
		| Item | Widget |
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp'
	Then the value of variable 'resp' matches the regex pattern '"Item":"Widget"'
