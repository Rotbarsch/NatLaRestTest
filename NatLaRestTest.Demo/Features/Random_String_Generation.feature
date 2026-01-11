Feature: Random string generation using SetRandomString

# Demonstrates the usages of the random string generation step for all supported types

Scenario Outline: Generate random '<Type>' string and ensure it is non-empty
	When a random '<Type>' string is stored in variable 'val'
	Then the value of variable 'val' is not empty
	And the value of variable 'val' is more than '0' characters long

Examples:
	| Type         |
	| FirstName    |
	| LastName     |
	| FullName     |
	| UserName     |
	| Email        |
	| PhoneNumber  |
	| CompanyName  |
	| JobTitle     |
	| City         |
	| Country      |
	| StreetAddress|
	| ZipCode      |
	| Url          |
	| Word         |
	| Sentence     |
	| Ipv4         |
	| Ipv6         |
	| Guid         |

Scenario: Email specific assertions
	When a random 'Email' string is stored in variable 'email'
	Then the value of variable 'email' contains '@'
	And the value of variable 'email' does not start with '@'

Scenario: URL specific assertions
	When a random 'Url' string is stored in variable 'url'
	Then the value of variable 'url' starts with 'http'
	And the value of variable 'url' does not end with ' '

Scenario: IPv4 specific assertions
	When a random 'Ipv4' string is stored in variable 'ipv4'
	Then the value of variable 'ipv4' contains '.'

Scenario: IPv6 specific assertions
	When a random 'Ipv6' string is stored in variable 'ipv6'
	Then the value of variable 'ipv6' contains ':'

Scenario: GUID specific assertions
	When a random 'Guid' string is stored in variable 'guid'
	Then the value of variable 'guid' contains '-'
	And the value of variable 'guid' is '36' characters long

Scenario: Full name contains a space
	When a random 'FullName' string is stored in variable 'fullName'
	Then the value of variable 'fullName' contains ' '

Scenario: Username should not contain '@'
	When a random 'UserName' string is stored in variable 'userName'
	Then the value of variable 'userName' does not contain '@'

Scenario: Street address is of reasonable length
	When a random 'StreetAddress' string is stored in variable 'street'
	Then the value of variable 'street' is more than '5' characters long

Scenario: Zip code is non-trivial length
	When a random 'ZipCode' string is stored in variable 'zip'
	Then the value of variable 'zip' is more than '3' characters long

Scenario: Sentence is longer than a single word
	When a random 'Sentence' string is stored in variable 'sentence'
	Then the value of variable 'sentence' is more than '5' characters long
