Feature: RegEx

Scenario: RegEx
	When the value 'NatLaRestTest' is stored in variable 'regex_var'
	Then the value of variable 'regex_var' matches the regex pattern 'NatLa.*Test'
	And the value of variable 'regex_var' does not match the regex pattern '\d\d\d'
