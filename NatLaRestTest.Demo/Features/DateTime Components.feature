Feature: DateTime variables - Component extraction

Scenario Outline: DateTime component exctraction
	When the value '2026-03-16T23:12:08.1234567' is stored in variable 'date'
	And the '<comp>' component of '$(date)' is stored in variable 'comp_value'
	Then the value of variable 'comp_value' equals '<expected>'

Examples:
	| comp        | expected                    |
	| Ticks       | 639092995281234567          |
	| Date        | 2026-03-16 |
	| Day         | 16                          |
	| DayOfWeek   | Monday                      |
	| DayOfYear   | 75                          |
	| Hour        | 23                          |
	| Microsecond | 456                         |
	| Millisecond | 123                         |
	| Minute      | 12                          |
	| Month       | 3                           |
	| NanoSecond  | 700                         |
	| Second      | 8                           |
	| TimeOfDay   | 23:12:08.1234567            |
	| Year        | 2026                        |