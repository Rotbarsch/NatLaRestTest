Feature: File and external variables

Keep in mind: All these variables are defined in ExampleVariables.Test.json, controlled by the NatlaRestTestSettings.json (and corresponding *.Development.json) file.

Scenario: Read from file
	When the content of file 'TestData/ExampleFile.txt' is stored in variable 'fileContent'
	Then the value of variable 'fileContent' is not null
	And the value of variable 'fileContent' equals 'TestString'

Scenario: Load additional variables files
	Given the variables file 'TestData/ExampleVariables.json' is loaded
	Then the value of variable 'exampleString' equals 'Testing'
	And the value of variable 'exampleNumber' equals '42'
	And the value of variable 'exampleNull' is null

Scenario: Recursive variable syntax resolve
	When the value 'variableValue' is stored in variable 'varName'
	And the value '42' is stored in variable 'variableValue'
	And the value '$($(varName))' is stored in variable 'result'
	Then the value of variable 'result' equals '42'