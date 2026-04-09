Feature: HttpClient Stream Upload

Upload file contents as stream content in HTTP requests.

Background:
	Given SSL certificate validation is disabled
	And the base URL '$(demoApiBaseUrl)'

Scenario: Upload file as stream content with POST
	When a 'POST' request is made to '/upload' with the contents of file 'TestData/UploadFile.txt' as stream content
	Then the response indicates success
	And the response code equals '200'

Scenario: Upload file as stream content with PUT
	When a 'PUT' request is made to '/upload' with the contents of file 'TestData/UploadFile.txt' as stream content
	Then the response indicates success
	And the response code equals '200'

Scenario: Upload file as stream content with explicit content type
	When a 'POST' request is made to '/upload' with the contents of file 'TestData/UploadFile.txt' as stream content with content type 'multipart/form-data'
	Then the response indicates success
	And the response code equals '200'

Scenario: Upload file as stream content to a ReadFormAsync endpoint
	When a 'POST' request is made to '/upload/form' with the contents of file 'TestData/UploadFile.txt' as stream content with content type 'text/plain'
	Then the response indicates success
	And the response code equals '200'

Scenario: Upload file as stream content with custom form field name
	When a 'POST' request is made to '/upload/form/named' with the contents of file 'TestData/UploadFile.txt' as stream content with content type 'text/plain' and form field name 'document'
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp'
	Then the value of variable 'resp' matches the regex pattern '"fieldName":"document"'
