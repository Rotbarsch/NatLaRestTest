Feature: JSON Schema assertions

Scenario: Validate simple object against schema
	When the following value is stored in variable 'sampleJson':
		"""
		{
		  "name": "Widget",
		  "price": 9.99,
		  "inStock": true
		}
		"""
	Then the value of variable 'sampleJson' matches the JSON schema:
		"""
		{
		  "$schema": "https://json-schema.org/draft/2020-12/schema",
		  "type": "object",
		  "required": ["name", "price", "inStock"],
		  "properties": {
		    "name": { "type": "string" },
		    "price": { "type": "number", "minimum": 0 },
		    "inStock": { "type": "boolean" }
		  },
		  "additionalProperties": false
		}
		"""
