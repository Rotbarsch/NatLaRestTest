Feature: HttpClient - NTLM

These tests leverage the negotiate of Kestrel, so they naturally only work on windows.

Background:
	Given SSL certificate validation is disabled
	And the base URL '$(demoApiBaseUrl)'

@windows-only
Scenario: NTLM off returns 401
	When a 'GET' request to '/require-ntlm' is made
	Then the response code equals '401'

@windows-only
Scenario: NTLM on returns 200
	Given NTLM authentication is enabled
	When a 'GET' request to '/require-ntlm' is made
	Then the response code equals '200'