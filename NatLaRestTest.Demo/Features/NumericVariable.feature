Feature: Numeric variables

Scenario: Basic functionality - comparisons
	When the value '13.37' is stored in variable 'num_var'
	Then the value of variable 'num_var' is greater than '13.36'
	Then the value of variable 'num_var' is less than '13.38'

Scenario: Basic functionaly - arithmetics
	When the value '10' is stored in variable 'ari_var'
	And the number '5' is added to the value of variable 'ari_var'
	And the value of variable 'ari_var' is multiplied with the number '2'
	And the value of variable 'ari_var' is divided by the number '6'
	And the number '2' is subtracted from the value of variable 'ari_var'
	Then the value of variable 'ari_var' equals '3'
	