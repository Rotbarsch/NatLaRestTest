Feature: Upload Stream

A short summary of the feature

Scenario: Uploading a stream
	Given the base URL '$(demoApiBaseUrl)'
	When a 'POST' request is made to '/upload' with the contents of file 'cat.jpg' as stream content
	Then the response code equals '200'
	
