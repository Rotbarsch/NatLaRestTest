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

Scenario Outline: DateTime comparison
	When the value '<d1>' is stored in variable 'date1'
	And the value '<d2>' is stored in variable 'date2'
	Then the value of variable 'date1' is greater than '$(date2)'
	And the value of variable 'date2' is less than '$(date1)'

Examples:
	| d1                        | d2                        |
	| 2025-01-16 08:00:00       | 2024-12-31 23:59:59       |
	| 2025-01-16                | 2024-12-31                |
	| 01/16/2025                | 12/31/2024                |
	| January 16, 2025          | December 31, 2024         |
	| 16 Jan 2025               | 31 Dec 2024               |
	| Thu, 16 Jan 2025          | Tue, 31 Dec 2024          |
	| 2025-01-16T10:00:00       | 2024-12-31T23:59:59       |
	| 2025-01-16T10:00:00Z      | 2024-12-31T23:59:59Z      |
	| 2025-01-16T10:00:00+02:00 | 2024-12-31T23:59:59+02:00 |
	| 2025-01-16T10:00:00-05:00 | 2024-12-31T23:59:59-05:00 |