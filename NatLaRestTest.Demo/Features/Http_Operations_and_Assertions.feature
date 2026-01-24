Feature: HTTP operations and assertions

Background: 
	Given SSL certificate validation is disabled

# Covers HTTP requests with explicit content type, response assertions, response body storage,
# JSONPath value extraction and string/length/numeric assertions on JSONPath selections
Scenario: HTTP create and fetch with JSONPath assertions
	Given the base URL '$(demoApiBaseUrl)'

	When a random 'Word' string is stored in variable 'newName'
	And a 'POST' request to '/objects' is made with content type 'application/json' and the following request body:
		"""
		{
			"name": "$(newName)",
			"data": {
				"year": 2020,
				"price": 9.99,
				"CPU model": "Z80",
				"Hard disk size": "1kB"
			}
		}
		"""
	Then the response code equals '200'
	And the response indicates success

	When the response body is stored in variable 'created'
	Then the value of JSONPath '$.name' in variable 'created' equals '$(newName)'
	When the value of JSONPath '$.id' in variable 'created' is stored in variable 'createdId'
	Then the value of variable 'createdId' is not null

	When a request to '/objects/$(createdId)' is made
	And a 'GET' request to '/objects/$(createdId)' is made
	Then the response code equals '200'
	And the response code does not equal '404'
	And the response indicates success

	When the response body is stored in variable 'fetched'
	Then the value of JSONPath '$.id' in variable 'fetched' equals '$(createdId)'
	And the value of JSONPath '$.name' in variable 'fetched' contains '$(newName)'
	And the value of JSONPath '$.name' in variable 'fetched' does not equal 'Wrong Name'
	And the value of JSONPath '$.name' in variable 'fetched' is more than '1' characters long
	And the value of JSONPath '$.name' in variable 'fetched' is not empty
	And the value of JSONPath '$.data' in variable 'fetched' contains 'CPU model'
	And the value of JSONPath '$.data.year' in variable 'fetched' is greater than '2000'
	And the value of JSONPath '$.data.price' in variable 'fetched' is less than '100'

# Covers HTTP request with body without explicit content type
Scenario: HTTP create without explicit content type
	Given the base URL '$(demoApiBaseUrl)'
	When a random 'Word' string is stored in variable 'newName2'
	And a 'POST' request to '/objects' is made with the following request body:
		"""
		{
			"name": "$(newName2)",
			"data": {
				"year": 2021,
				"price": 19.99
			}
		}
		"""
	Then the response indicates success
	When the response body is stored in variable 'created2'
	Then the value of JSONPath '$.name' in variable 'created2' equals '$(newName2)'

# Example of request with body 
Scenario: Showcase on POST /objects endpoint
	Given the base URL '$(demoApiBaseUrl)'

	When the value 'Apple MacBook Pro 16 (which was thrown out of a window)' is stored in variable 'newName'
	When a 'POST' request to '/objects' is made with the following request body:
		"""
		{
			"name": "$(newName)",
			"data": {
				"year":2019,
				"price": 4999.99,
				"CPU model": "Z80",
				"Hard disk size": "1kB"
			}
		}
		"""
	Then the response code equals '200'
	And the response indicates success
	
	When the response body is stored in variable 'updatedEntity'
	Then the value of JSONPath '$.name' in variable 'updatedEntity' equals '$(newName)'

# Copy to demonstrate variable scopes
Scenario: Showcase on POST /objects endpoint (copy to show variable thing)
	Given the base URL '$(demoApiBaseUrl)'

	When the value 'NEW_NAME' is stored in variable 'newName'
	When a 'POST' request to '/objects' is made with the following request body:
		"""
		{
			"name": "$(newName)",
			"data": {
				"year":2019,
				"price": 4999.99,
				"CPU model": "Z80",
				"Hard disk size": "1kB"
			}
		}
		"""
	Then the response code equals '200'
	And the response indicates success
	
	When the response body is stored in variable 'updatedEntity'
	Then the value of JSONPath '$.name' in variable 'updatedEntity' equals 'NEW_NAME'

# Example of DELETE request without body
Scenario: Showcase on DELETE /objects endpoint
	Given the base URL '$(demoApiBaseUrl)'
	When a random 'Word' string is stored in variable 'newName'	
	When a 'POST' request to '/objects' is made with the following request body:
		"""
		{
			"name": "$(newName)",
			"data": {
				"year":2019,
				"price": 4999.99,
				"CPU model": "Z80",
				"Hard disk size": "1kB"
			}
		}
		"""
	Then the response indicates success
	When the response body is stored in variable 'createResult'
	When the value of JSONPath '$.id' in variable 'createResult' is stored in variable 'createdId'

	When a 'DELETE' request to '/objects/$(createdId)' is made 
	Then the response code equals '200'
	And the response indicates success

	When the response body is stored in variable 'deleteResult'
	Then the value of JSONPath '$.message' in variable 'deleteResult' contains 'has been deleted'
	And the value of JSONPath '$.message' in variable 'deleteResult' contains 'id = $(createdId)'

# Covers response not success assertion
Scenario: Non-success response
	Given the base URL '$(demoApiBaseUrl)'

	When a 'GET' request to '/objects/99999999' is made
	Then the response does not indicate success
	And the response code does not equal '200'

# Scenario: Downloading a stream
Scenario: Downloading a stream
	Given the base URL '$(demoApiBaseUrl)'
	
	When a request to '/cat' is made
	And the length of the response stream is stored in variable 'streamLength'
	Then the response code equals '200'
	And the value of variable 'streamLength' is greater than '0'
	
	When the response stream is saved to file 'cat.jpg'
	And the value of header 'Server' is stored in variable 'serverHeader'
	Then the value of variable 'serverHeader' equals 'Kestrel'
