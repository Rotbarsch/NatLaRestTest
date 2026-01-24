Feature: DateTime variables

Background:
	When the value '2026' is stored in variable 'currentYear'

Scenario: Setting CurrentTime
	When the current date is stored in variable 'now'
	Then the value of variable 'now' starts with '$(currentYear)'

	When the date '2025-01-16' is stored in variable 'f_date' in format 'yyyyMMdd'
	Then the value of variable 'f_date' equals '20250116'

	When the current date is stored in variable 'now_f' in format 'yyyy'
	Then the value of variable 'now_f' equals '$(currentYear)'

Scenario: DateTime arithmetic
	When the date '2025-01-16 08:00:00' is stored in variable 'dt_ar' in format 'O'
	And the timespan '01:30:00' is added to the value of variable 'dt_ar'
	Then the value of variable 'dt_ar' starts with '2025-01-16T09:30:00'
	When the timespan '00:30:00' is subtracted from the value of variable 'dt_ar'
	Then the value of variable 'dt_ar' starts with '2025-01-16T09:00:00'