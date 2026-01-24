Feature: XPath

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