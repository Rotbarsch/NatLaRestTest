Feature: JSONPath string assertions

# Covers the full set of JSONPath string assertions including negatives and emptiness
Scenario: JSONPath string assertion variations
	When the following value is stored in variable 'sampleJson':
		"""
		{ "path": "/root/item/1", "empty": "" }
		"""
	
	Then the value of JSONPath '$.path' in variable 'sampleJson' returns any value
	And the value of JSONPath '$.path' in variable 'sampleJson' contains 'root'
	And the value of JSONPath '$.path' in variable 'sampleJson' does not contain 'products'
	And the value of JSONPath '$.path' in variable 'sampleJson' starts with '/root'
	And the value of JSONPath '$.path' in variable 'sampleJson' does not start with 'http'
	And the value of JSONPath '$.path' in variable 'sampleJson' ends with '/1'
	And the value of JSONPath '$.path' in variable 'sampleJson' does not end with '/2'
	And the value of JSONPath '$.path' in variable 'sampleJson' is '12' characters long
	And the value of JSONPath '$.path' in variable 'sampleJson' is not empty
	And the value of JSONPath '$.path' in variable 'sampleJson' is more than '5' characters long
	And the value of JSONPath '$.path' in variable 'sampleJson' is less than '100' characters long
	And the value of JSONPath '$.empty' in variable 'sampleJson' is empty

# Demonstrate multiline comparison parameters for JSONPath string assertions
Scenario: JSONPath string assertions with multiline comparison
	When the following value is stored in variable 'jsonMultiline':
		"""
		{ "message": "Line 1\nLine 2\nLine 3" }
		"""
	Then the value of JSONPath '$.message' in variable 'jsonMultiline' equals:
		"""
		Line 1
		Line 2
		Line 3
		"""
	And the value of JSONPath '$.message' in variable 'jsonMultiline' does not equal:
		"""
		Line 1
		Line X
		Line 3
		"""
	And the value of JSONPath '$.message' in variable 'jsonMultiline' contains:
		"""
		Line 2
		"""
	And the value of JSONPath '$.message' in variable 'jsonMultiline' does not contain:
		"""
		Line 4
		"""
	And the value of JSONPath '$.message' in variable 'jsonMultiline' starts with:
		"""
		Line 1
		"""
	And the value of JSONPath '$.message' in variable 'jsonMultiline' does not end with:
		"""
		Line 4
		"""
