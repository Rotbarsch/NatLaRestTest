Feature: Random data

Scenario: Random string
	When a random 'Word' string is stored in variable 'rand_word'
	Then the value of variable 'rand_word' is not empty

Scenario: Random numbers - Integer
	When a random integer between '1' and '3' is stored in variable 'rand_int'
	Then the value of variable 'rand_int' is greater than '0'
	And the value of variable 'rand_int' is less than '3.1'

Scenario: Random numbers - Double
	When a random double between '0.1' and '0.3' is stored in variable 'rand_double'
	Then the value of variable 'rand_double' is greater than '0'
	And the value of variable 'rand_double' is less than '0.31'