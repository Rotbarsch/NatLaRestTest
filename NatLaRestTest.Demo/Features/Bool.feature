Feature: Bool variables

Scenario: Basic functionality
	When the value 'true' is stored in variable 'var_true'
	And the value 'false' is stored in variable 'var_false'
	
	Then the value of variable 'var_true' is true
	And the value of variable 'var_false' is false