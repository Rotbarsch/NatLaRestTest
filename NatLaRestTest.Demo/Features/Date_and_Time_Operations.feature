Feature: Date and time operations

# Covers adding/subtracting TimeSpan to/from a DateTime variable
Scenario: DateTime add and subtract timespan
	When the value '2024-01-01T12:00:00' is stored in variable 'dt3'
	And the timespan '01:30:00' is added to the value of variable 'dt3'
	And the timespan '01:00:00' is subtracted from the value of variable 'dt3'
	And the date '2024-01-01T12:00:00' is subtracted from the value of variable 'dt3'
	Then the value of variable 'dt3' equals '00:30:00'

# Covers current date steps (now and formatted)
Scenario: Current date variable steps
	When the current date is stored in variable 'now'
	Then the value of variable 'now' is not null
	And the value of variable 'now' is more than '0' characters long
	When the current date is stored in variable 'nowFmt' in format 'yyyy-MM-dd'
	Then the value of variable 'nowFmt' is '10' characters long
