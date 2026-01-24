Feature: Basic variables

Scenario: Basic functionality
	When the value 'Hello, World' is stored in variable 'var1'
	Then the value of variable 'var1' is not null
	And the value of variable 'var1' equals 'Hello, World'

Scenario: Multiline
	When the following value is stored in variable 'multiline_var':
	"""
	Hello,
	World
	"""
	Then the value of variable 'multiline_var' is not null
	And the value of variable 'multiline_var' equals:
	"""
	Hello,
	World
	"""

Scenario: Null
	When the value of variable 'null_var' is set to null
	Then the value of variable 'null_var' is null