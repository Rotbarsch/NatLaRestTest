Feature: OAuth

This OAuth example uses a free-tier Auth0 account. Configure it yourself in TestData/oauth.json.

Background:
	Given the variables file 'TestData/oauth.json' is loaded
	And OAuth is configured with the following parameters:
	| Field         | Value                  |
	| TokenEndpoint | $(oauth.tokenendpoint) |
	| ClientID      | $(oauth.clientid)      |
	| ClientSecret  | $(oauth.clientsecret)  |
	| Audience      | $(oauth.audience)      |
	And the base URL '$(oauth.baseurl)'

Scenario: OAuth
	When a 'GET' request to '/clients' is made
	Then the response code does not equal '401'
	And the response code equals '404'
