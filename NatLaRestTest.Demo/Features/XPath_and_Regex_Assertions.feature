Feature: XPath and regex assertions

# Small demo of XPath extraction into a variable using XML stored in 'xml'
Scenario: XPath extraction demo
	When the following value is stored in variable 'xml':
		"""
		<root>
		  <item id="123">value</item>
		</root>
		"""
	And when the value of XPath '/root/item/@id' is stored in variable 'xmlId'
	Then the value of variable 'xmlId' equals '123'

# Covers regex assertions on variables
Scenario: Regex assertion demo
	When the value 'user.name+test@example.com' is stored in variable 'email'
	Then the value of variable 'email' matches the regex pattern '^[^@\s]+@[^@\s]+\.[^@\s]+$'
