Feature: Collection variables

Scenario: Basic functionality
	When the following value is stored in variable 'arr':
		"""
		[1,2,3]
		"""
	And the following value is stored in variable 'empty_arr':
	"""
	[]
	"""
	Then the value of variable 'arr' has any elements
	And the value of variable 'empty_arr' has no elements
	And the value of variable 'arr' has more than '1' elements
	And the value of variable 'arr' has less than '4' elements
	And the value of variable 'arr' has '3' elements