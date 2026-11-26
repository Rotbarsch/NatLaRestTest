Feature: Concurrent HTTP Requests

Send HTTP requests concurrently and store each response code and body independently.

Background:
    Given SSL certificate validation is disabled
    And the base URL '$(demoApiBaseUrl)'

Scenario: Send concurrent requests and override a configured header per row
    Given the default header 'x-application' with value 'wrong'
    When the following HTTP requests are sent concurrently:
        | HTTP method | Request URL           | Body | Headers                                  | Response code variable | Response body variable |
        | GET         | /require-natla-header |      | x-application=NatLaRestTest              | overriddenCode         | overriddenBody         |
        | GET         | /require-natla-header |      |                                          | defaultCode            | defaultBody            |
        | POST        | /upload               | text | Content-Type="text/plain; charset=utf-8" | contentTypeCode        | contentTypeBody        |
    Then the value of variable 'overriddenCode' equals '200'
    And the value of variable 'defaultCode' equals '400'
    And the value of variable 'contentTypeCode' equals '200'
    And the value of variable 'contentTypeBody' matches the regex pattern '"contentType":"text/plain; charset=utf-8"'

Scenario: Send concurrent requests without a Headers column
    When the following HTTP requests are sent concurrently:
        | HTTP method | Request URL | Body                | Response code variable | Response body variable |
        | POST        | /upload     | first request body  | firstCode              | firstBody              |
        | POST        | /upload     | second request body | secondCode             | secondBody             |
    Then the value of variable 'firstCode' equals '200'
    And the value of variable 'secondCode' equals '200'
    And the value of variable 'firstBody' matches the regex pattern '"content":"first request body"'
    And the value of variable 'secondBody' matches the regex pattern '"content":"second request body"'
