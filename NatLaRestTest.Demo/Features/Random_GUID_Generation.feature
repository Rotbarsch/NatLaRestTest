Feature: Random GUID generation

# Covers additional random string type
Scenario: Random GUID string
	When a random 'Guid' string is stored in variable 'guidVal'
	Then the value of variable 'guidVal' is not empty
	And the value of variable 'guidVal' contains '-'
	And the value of variable 'guidVal' is more than '10' characters long
