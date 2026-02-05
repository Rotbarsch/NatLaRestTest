Feature: JSONPath Assertions


Scenario: Assert a property exists or does not exist
	When the following value is stored in variable 'items':
		"""		
		  { "id": 1, "price": 10, "available": false }		  		
		"""
	Then the JSONPath '$.id' is valid on value of variable 'items'
	But the JSONPath '$.nonExistentProperty' is not valid on value of variable 'items'

Scenario: Filter a collection by ensuring the property exists or does not exist
	When the following value is stored in variable 'items':
		"""		
		  [
		  { "id": 1, "price": 10, "available": false },
		  { "id": 2, "price": 20, "available": false },		  		
		  { "price": 30, "available": false }		  		
		  ]
		"""
	And each element of collection in variable 'items' where the value of JSONPath '$.id' is valid is stored in variable 'validItems'
	And each element of collection in variable 'items' where the value of JSONPath '$.id' is not valid is stored in variable 'invalidItems'
	Then the value of variable 'validItems' has '2' elements
	But the value of variable 'invalidItems' has '1' elements