Feature: JSONPath string assertions

# Covers the full set of JSONPath string assertions including negatives and emptiness
Scenario: JSONPath string assertion variations
	When the following value is stored in variable 'sampleJson':
		"""
		{ "path": "/root/item/1", "empty": "" }
		"""
	Then the value of JSONPath '$.path' in variable 'sampleJson' contains 'root'
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
