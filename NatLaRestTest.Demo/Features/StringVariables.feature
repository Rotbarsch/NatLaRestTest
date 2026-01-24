Feature: String variables

Scenario: String manipulation
	When the value ',' is stored in variable 'hello_world'
	And the string 'Hello' is prepended to the value of variable 'hello_world'
	And the string 'World' is appended to the value of variable 'hello_world'
	Then the value of variable 'hello_world' equals 'Hello,World'
	When the string 'World' is replaced with 'Planet' in the value of variable 'hello_world'
	Then the value of variable 'hello_world' equals 'Hello,Planet'
	And the value of variable 'hello_world' does not equal 'Hello,World'

Scenario: String length
	When the length of string 'abcdef' is stored in variable 'str_len'
	Then the value of variable 'str_len' equals '6'

Scenario: Substring
	When the substring from index '2' and length '3' is extracted from 'abcdef' and stored in variable 'sub_str'
	Then the value of variable 'sub_str' equals 'cde'

Scenario: String Assertions
	When the value '' is stored in variable 'empty_str'
	When the value 'NatLaRestTest' is stored in variable 'str_man'
	Then the value of variable 'str_man' is not empty
	And the value of variable 'empty_str' is empty
	And the value of variable 'str_man' starts with 'Nat'
	And the value of variable 'str_man' does not start with 'taN'
	And the value of variable 'str_man' ends with 'Test'
	And the value of variable 'str_man' does not end with 'tseT'
	And the value of variable 'str_man' contains 'LaRest'
	And the value of variable 'str_man' does not contain 'Wurst'