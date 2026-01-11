Feature: Collection assertions

# Covers direct collection variable assertions
Scenario: Collection variable assertions
	When the following value is stored in variable 'arr':
		"""
		[1,2,3]
		"""
	Then the value of variable 'arr' has any elements
	And the value of variable 'arr' is not null
	And the value of variable 'arr' has more than '0' elements
	And the value of variable 'arr' has less than '10' elements
	And the value of variable 'arr' has '3' elements

	When the following value is stored in variable 'emptyArr':
		"""
		[]
		"""
	Then the value of variable 'emptyArr' has no elements

# Covers JSONPath collection count assertions comprehensively on a local JSON variable
Scenario: JSONPath collection count assertions
	When the following value is stored in variable 'jsonArr':
		"""
		{ "nums": [1,2,3] }
		"""
	Then the value of JSONPath '$.nums' in variable 'jsonArr' has any elements
	And the value of JSONPath '$.nums' in variable 'jsonArr' has more than '2' elements
	And the value of JSONPath '$.nums' in variable 'jsonArr' has less than '5' elements
	And the value of JSONPath '$.nums' in variable 'jsonArr' has '3' elements
