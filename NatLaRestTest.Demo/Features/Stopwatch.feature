Feature: Stopwatch bindings

Scenario: Basic functionality
	When a stopwatch named 'sw1' is started
	And test execution is paused for '2' seconds
	And the stopwatch 'sw1' is stopped
	And the elapsed time of stopwatch 'sw1' is stored in variable 'swv1'
	Then the value of variable 'swv1' is greater than '1.9'
	When the stopwatch 'sw1' is resumed
	And test execution is paused for '1' seconds
	And the elapsed time of stopwatch 'sw1' is stored in variable 'swv1'
	Then the value of variable 'swv1' is greater than '2.9'


Scenario: Multiple stopwatches
	When a stopwatch named 'msw1' is started
	And a stopwatch named 'msw2' is started
	And test execution is paused for '1' seconds
	And the stopwatch 'msw1' is stopped
	And test execution is paused for '1' seconds
	And the stopwatch 'msw2' is stopped
	And the elapsed time of stopwatch 'msw1' is stored in variable 'mswv1'
	And the elapsed time of stopwatch 'msw2' is stored in variable 'mswv2'
	Then the value of variable 'mswv1' is greater than '0.9'
	And the value of variable 'mswv1' is less than '2'
	And the value of variable 'mswv2' is greater than '1.9'