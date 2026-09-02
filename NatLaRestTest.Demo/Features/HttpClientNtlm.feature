Feature: HttpClient - NTLM

Execute this test manually with a manually started DemoWebApi - NTLM is not applicable when the API is started by the test itself, it needs IIS Express.

Background:
	Given SSL certificate validation is disabled
	And the base URL 'http://localhost:5080'	

@manual
Scenario: NTLM off returns 401
	When a 'GET' request to '/require-ntlm' is made
	Then the response code equals '401'

@manual
Scenario: NTLM on returns 200
	Given NTLM authentication is enabled
	When a 'GET' request to '/require-ntlm' is made
	Then the response code equals '200'