Feature: Usage of Scenario Outlines and Examples

Background:
	When the value '1' is stored in variable 'vA'
	And the value '2' is stored in variable 'vB'
	And the value '3' is stored in variable 'vC'

Scenario Outline: Variables in examples
	When the value '<Value>' is stored in variable '<Variable>'
	Then the value of variable '<Variable>' equals '<Value>'
	
Examples:
	| Variable | Value |
	| A        | $(vA) |
	| B        | $(vB) |
	| C        | $(vC) |