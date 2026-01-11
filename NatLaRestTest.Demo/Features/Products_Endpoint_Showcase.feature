Feature: Products endpoint showcase

Scenario: Showcase on /products endpoint
	Given the base URL '$(demoApiBaseUrl)'

	# Basic sending of a get request
	When a request to 'products' is made 
	Then the response code equals '200'
	And the response code does not equal '404'
	And the response indicates success

	# Storing the response body in a variable for later usage
	When the response body is stored in variable 'listResponseBody'
	And the value of JSONPath '$.products' in variable 'listResponseBody' is stored in variable 'productsList'
	
	# Assertions of variables of type collection
	Then the value of variable 'productsList' has any elements
	And the value of variable 'productsList' is not null
	And the value of variable 'productsList' has more than '0' elements
	And the value of variable 'productsList' has less than '1000' elements
	And the value of variable 'productsList' has '2' elements

	# Storing an object in a variable
	When the value of JSONPath '$.[0]' in variable 'productsList' is stored in variable 'firstProduct'
	
	# Asserts of JSON string property
	Then the value of JSONPath '$.name' in variable 'firstProduct' equals 'Banana'
	And the value of JSONPath '$.name' in variable 'firstProduct' does not equal 'Apple'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' contains 'products/1'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' does not contain 'products/2'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' starts with '/shop'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' does not start with 'http'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' ends with '/1'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' does not end with '/2'
	And the value of JSONPath '$.self_link' in variable 'firstProduct' is '19' characters long
	And the value of JSONPath '$.self_link' in variable 'firstProduct' is not empty
	And the value of JSONPath '$.self_link' in variable 'firstProduct' is more than '1' characters long
	And the value of JSONPath '$.self_link' in variable 'firstProduct' is less than '100' characters long

	# Asserts of JSON numeric property	
	And the value of JSONPath '$.id' in variable 'firstProduct' equals '1'
	And the value of JSONPath '$.id' in variable 'firstProduct' is greater than '0'
	And the value of JSONPath '$.id' in variable 'firstProduct' is less than '100'
	
	# Asserts on a JSON string variable
	When the value of JSONPath '$.self_link' in variable 'firstProduct' is stored in variable 'firstProductLink'
	Then the value of variable 'firstProductLink' is more than '0' characters long
	And the value of variable 'firstProductLink' is less than '100' characters long
	And the value of variable 'firstProductLink' is '19' characters long
	And the value of variable 'firstProductLink' is not empty
	And the value of variable 'firstProductLink' starts with '/shop'
	And the value of variable 'firstProductLink' ends with '/1'
	And the value of variable 'firstProductLink' does not start with 'http'
	And the value of variable 'firstProductLink' does not end with '.de'
	And the value of variable 'firstProductLink' contains 'products'
	And the value of variable 'firstProductLink' does not contain 'categories'
	And the value of variable 'firstProductLink' equals '/shop/v2/products/1'
	And the value of variable 'firstProductLink' does not equal '/shop/products/2'

	# Reusing the value in a variable somewhere else, in this case as a parameter of a web request
	When the value of JSONPath '$.id' in variable 'firstProduct' is stored in variable 'firstProductId'
	And a request to 'products/$(firstProductId)' is made

	Then the response indicates success
	When the response body is stored in variable 'singleProduct'
	Then the value of JSONPath '$.name' in variable 'singleProduct' equals 'Banana'
	
	# Assertions on a JSON numeric variable
	And the value of JSONPath '$.price' in variable 'singleProduct' equals '0.99'
	And the value of JSONPath '$.price' in variable 'singleProduct' is greater than '0'
	And the value of JSONPath '$.price' in variable 'singleProduct' is less than '1'

	When the value of JSONPath '$.price' in variable 'singleProduct' is stored in variable 'singleProductPrice'
	
	# Assertions on a numeric variable
	Then the value of variable 'singleProductPrice' equals '0.99'
	And the value of variable 'singleProductPrice' is greater than '0'
	And the value of variable 'singleProductPrice' is less than '1'
