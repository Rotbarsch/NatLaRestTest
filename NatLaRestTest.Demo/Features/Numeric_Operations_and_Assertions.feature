Feature: Numeric operations and assertions

# Covers random number generation, numeric manipulations and numeric assertions
Scenario: Numeric operations and assertions
	When a random integer between 1 and 10 is stored in variable 'randInt'
	Then the value of variable 'randInt' is greater than '0'
	And the value of variable 'randInt' is less than '11'

	When a random double between 0 and 1 is stored in variable 'randDouble'
	Then the value of variable 'randDouble' is greater than '0'
	And the value of variable 'randDouble' is less than '1'

	When the value '10' is stored in variable 'num'
	And the number '5' is added to the value of variable 'num'
	And the number '2' is multiplied with the value of variable 'num'
	And the value of variable 'num' is divided by the number '3'
	And the number '100' is divided by the value of variable 'num'
	And the number '4' is subtracted from the value of variable 'num'
	And the value of variable 'num' is subtracted from the number '10'
	Then the value of variable 'num' equals '4'
	And the value of variable 'num' is greater than '0'
	And the value of variable 'num' is less than '10'
