Feature: Numeric variables

Scenario: Basic functionality - comparisons
	When the value '13.37' is stored in variable 'num_var'
	Then the value of variable 'num_var' is greater than '13.36'
	Then the value of variable 'num_var' is less than '13.38'

Scenario: Basic functionaly - arithmetics
	When the value '10' is stored in variable 'ari_var'
	And the sum of '$(ari_var)' plus '5' is stored in variable 'ari_result_add'
	Then the value of variable 'ari_result_add' equals '15'
	
	When the difference of '$(ari_var)' minus '3' is stored in variable 'ari_result_sub'
	Then the value of variable 'ari_result_sub' equals '7'

	When the quotient of '$(ari_var)' divided by '4' is stored in variable 'ari_result_div'
	Then the value of variable 'ari_result_div' equals '2.5'

	When the product of '$(ari_var)' multiplied by '2' is stored in variable 'ari_result_mul'
	Then the value of variable 'ari_result_mul' equals '20'
