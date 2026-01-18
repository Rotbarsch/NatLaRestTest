Feature: XPath and regex assertions

# Small demo of XPath extraction into a variable using XML stored in 'xml'
Scenario: XPath Assertion
	When the following value is stored in variable 'sampleXml':
		"""
		<root>
			<item>Value1</item>
			<item>Value2</item>
		</root>
		"""
	
	And the result of XPath '/root/item[1]/text()' in the value of variable 'sampleXml' is stored in variable 'xPathResult'
	Then the value of variable 'xPathResult' equals 'Value1'

# Covers regex assertions on variables
Scenario: Regex assertion demo
	When the value 'user.name+test@example.com' is stored in variable 'email'
	Then the value of variable 'email' matches the regex pattern '^[^@\s]+@[^@\s]+\.[^@\s]+$'
