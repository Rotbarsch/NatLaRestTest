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

Scenario: Store collection length in variable
	When the following value is stored in variable 'myCollection':
		"""
		[1,2,3,4,5]
		"""
	And the following value is stored in variable 'emptyCollection':
		"""
		[]
		"""
	And the length of collection variable 'myCollection' is stored in variable 'collectionLength'
	And the length of collection variable 'emptyCollection' is stored in variable 'emptyCollectionLength'
	Then the value of variable 'collectionLength' equals '5'
	And the value of variable 'emptyCollectionLength' equals '0'