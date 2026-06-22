Feature: HttpClient

The demoApiBaseUrl variable is read from reqnroll.json Use the tests in here with a running instance of the NatLaRestTest.DemoWebApi project.

Background:
	Given SSL certificate validation is disabled
	And the base URL '$(demoApiBaseUrl)'

Scenario: Basic functionality
	When a 'GET' request to '/ok' is made
	
	# response HTTP code
	Then the response indicates success
	And the response code equals '200'
	
	# response body
	When the response body is stored in variable 'resp_body'
	Then the value of variable 'resp_body' equals '"works"'
	
	# Response time
	When the response time is stored in variable 'resp_time'
	Then the value of variable 'resp_time' is greater than '0'

	# Headers
	When the value of content header 'Expires' is stored in variable 'expiry'
	#Then the value of variable 'content_type' equals 'text/plain'
	When the value of header 'x-application' is stored in variable 'x_application'
	Then the value of variable 'x_application' equals 'NatLaDemoApi'

	# Example for post
	When a 'POST' request to '/create' is made with the following request body:
	"""
	{
		"name": "NatLaRestTest"
	}
	"""
	Then the response indicates success
	And the response code equals '201'

	When a 'GET' request to 'missing' is made
	Then the response code equals '404'
	And the response code does not equal '200'
	And the response does not indicate success	

Scenario: Set and remove default headers
	Given the default header 'x-application' with value 'NatLaRestTest'
	When a 'GET' request to '/require-natla-header' is made
	Then the response code equals '200'
	Given the default header 'x-application' is removed
	When a 'GET' request to '/require-natla-header' is made
	Then the response code equals '400'
	

	
	
