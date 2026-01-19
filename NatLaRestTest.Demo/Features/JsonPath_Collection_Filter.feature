Feature: JSONPath collection filtering

# Demonstrates filtering a JSON collection stored in a variable using various JSONPath-based comparison operations
Scenario: Filter objects in a collection by numeric comparisons
	When the following value is stored in variable 'items':
		"""
		[
		  { "id": 1, "price": 10 },
		  { "id": 2, "price": 20 },
		  { "id": 3, "price": 30 },
		  { "id": 4, "price": 40 }
		]
		"""
	When each element of collection in variable 'items' where the value of JSONPath '$.price' is greater than '20' is stored in variable 'expensiveItems'
	Then the value of variable 'expensiveItems' has '2' elements

	When each element of collection in variable 'items' where the value of JSONPath '$.price' is greater than or equal '30' is stored in variable 'gte30Items'
	Then the value of variable 'gte30Items' has '2' elements

	When each element of collection in variable 'items' where the value of JSONPath '$.price' is less than '20' is stored in variable 'lessThan20Items'
	Then the value of variable 'lessThan20Items' has '1' elements

	When each element of collection in variable 'items' where the value of JSONPath '$.price' is less than or equal '20' is stored in variable 'cheapOrEqualItems'
	Then the value of variable 'cheapOrEqualItems' has '2' elements

	When each element of collection in variable 'items' where the value of JSONPath '$.price' equals '30' is stored in variable 'exactPriceItems'
	Then the value of variable 'exactPriceItems' has '1' elements

	When each element of collection in variable 'items' where the value of JSONPath '$.price' does not equal '10' is stored in variable 'not10PriceItems'
	Then the value of variable 'not10PriceItems' has '3' elements

Scenario: Filter objects by string emptiness and null checks
	When the following value is stored in variable 'people':
		"""
		[
		  { "name": "Alice", "nickname": "Al" },
		  { "name": "Bob", "nickname": "" },
		  { "name": "Charlie", "nickname": null },
		  { "name": "Dana" }
		]
		"""
	When each element of collection in variable 'people' where the value of JSONPath '$.nickname' is empty is stored in variable 'emptyNicknames'
	Then the value of variable 'emptyNicknames' has '1' elements

	When each element of collection in variable 'people' where the value of JSONPath '$.nickname' is not empty is stored in variable 'nonEmptyNicknames'
	Then the value of variable 'nonEmptyNicknames' has '1' elements

	When each element of collection in variable 'people' where the value of JSONPath '$.nickname' is null is stored in variable 'nullNicknames'
	Then the value of variable 'nullNicknames' has '2' elements

	When each element of collection in variable 'people' where the value of JSONPath '$.nickname' is not null is stored in variable 'notNullNicknames'
	Then the value of variable 'notNullNicknames' has '2' elements

Scenario: Filter by nested collection element presence
	When the following value is stored in variable 'products':
		"""
		[
		  { "id": 1, "tags": ["new", "sale"] },
		  { "id": 2, "tags": [] },
		  { "id": 3 }
		]
		"""
	When each element of collection in variable 'products' where the value of JSONPath '$.tags' has elements is stored in variable 'taggedProducts'
	Then the value of variable 'taggedProducts' has '1' elements
	And the value of JSONPath '$[0].id' in variable 'taggedProducts' equals '1'

	When each element of collection in variable 'products' where the value of JSONPath '$.tags' has no elements is stored in variable 'untaggedProducts'
	Then the value of variable 'untaggedProducts' has '1' elements
	And the value of JSONPath '$[0].id' in variable 'untaggedProducts' equals '2'
	And the value of JSONPath '$[0].id' in variable 'taggedProducts' does not equal '3'
