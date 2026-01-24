Feature: Upload Stream

Background: 
	Given SSL certificate validation is disabled

Scenario: Uploading a stream
	Given the base URL '$(demoApiBaseUrl)'
	When a 'POST' request is made to '/upload' with the contents of file 'cat.jpg' as stream content
	Then the response code equals '200'
	
