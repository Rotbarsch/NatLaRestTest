Feature: String operations and assertions

# Covers string variable creation, manipulation, assertions, substring, multiline JSON and JSONPath collection assertions
Scenario: String operations and assertions
	When the value 'Hello' is stored in variable 'greeting'
	And the string ' World' is appended to the value of variable 'greeting'
	And the string 'Start: ' is prepended to the value of variable 'greeting'
	And the string 'World' is replaced with 'Universe' in the value of variable 'greeting'
	Then the value of variable 'greeting' equals 'Start: Hello Universe'
	And the value of variable 'greeting' does not equal 'Start: Hello World'
	And the value of variable 'greeting' starts with 'Start: Hello'
	And the value of variable 'greeting' ends with 'Universe'
	And the value of variable 'greeting' contains 'Hello'
	And the value of variable 'greeting' does not contain 'Goodbye'
	And the value of variable 'greeting' is not empty
	And the value of variable 'greeting' is more than '5' characters long
	And the value of variable 'greeting' is less than '100' characters long
	And the value of variable 'greeting' does not start with 'http'
	And the value of variable 'greeting' does not end with '.json'

	When the substring from index '3' and length '3' is extracted from 'abcdefghi' and stored in variable 'middle'
	And the length of string '$(middle)' is stored in variable 'middleStrLength'
	Then the value of variable 'middle' equals 'def'
	And the value of variable 'middle' is '3' characters long
	And the value of variable 'middleStrLength' equals '3'

	When the following value is stored in variable 'jsonManual':
		"""
		{ "items": [] }
		"""
	Then the value of JSONPath '$.items' in variable 'jsonManual' has no elements

	When the value '' is stored in variable 'emptyVar'
	Then the value of variable 'emptyVar' is empty
	And the value of variable 'nullExample' is null

# Demonstrate multiline comparison parameters for string variable assertions
Scenario: String variable assertions with multiline comparison
	When the following value is stored in variable 'multiLine':
		"""
		Line 1
		Line 2
		Line 3
		"""
	Then the value of variable 'multiLine' equals:
		"""
		Line 1
		Line 2
		Line 3
		"""
	And the value of variable 'multiLine' does not equal:
		"""
		Line 1
		Line X
		Line 3
		"""
	And the value of variable 'multiLine' contains:
		"""
		Line 2
		"""
	And the value of variable 'multiLine' does not contain:
		"""
		Line 4
		"""
	And the value of variable 'multiLine' starts with:
		"""
		Line 1
		"""
	And the value of variable 'multiLine' does not end with:
		"""
		Line 4
		"""

# Demonstrate boolean variable assertions
Scenario: Boolean variable assertions
	When the value 'true' is stored in variable 'featureEnabled'
	And the value 'false' is stored in variable 'isArchived'
	Then the value of variable 'featureEnabled' is true
	And the value of variable 'isArchived' is false
