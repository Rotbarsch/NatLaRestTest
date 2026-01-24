Feature: HttpClient

The demoApiBaseUrl variable is read from reqnroll.json

Background:
	Given SSL certificate validation is disabled
	And the base URL '$(demoApiBaseUrl)'

Scenario: Basic functionality
	When a 'GET' request to '/ok' is made
	Then the response indicates success
	And the response code equals '200'
	When the response body is stored in variable 'resp_body'
	Then the value of variable 'resp_body' equals '"works"'
	When the response time is stored in variable 'resp_time'
	Then the value of variable 'resp_time' is greater than '0'

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

	
	
