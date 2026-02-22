# ![Icon](./icon64.png) NatLaRestTest

*Natural Language REST API Testing Framework*

## Mission Statement
This project aims to simplify the process of testing REST APIs by leveraging natural language processing techniques, 
powered by the excellent [Reqnroll](https://github.com/reqnroll/Reqnroll). 
It allows testers to write test cases in plain English, making it easier for non-technical stakeholders to understand and contribute to the testing process.

**TL;DR: A set of Reqnroll Bindings for writing REST API tests in Natural Language.**

## Minimal Usage Example
```
Given the base URL 'https://awesome-api.de'
When a request to '/produces/1' is made
Then the response code equals '200'
```

See the NatLaRestTest.Demo project for more usage examples or the full listing of [implemented bindings](./Bindings.md).

## Advantages of using NatLaRestTest
- **Natural Language**: Write tests in plain English, making them accessible to non-technical team members.
- **Version control compatible**: Test cases can be easily managed and tracked using standard version control systems.
- **Ease of Use**: Simplifies the process of creating and maintaining REST API tests.
- **Integration with Reqnroll**: Leverages the powerful features of Reqnroll and its various integrations for REST API testing.
- **Flexibility**: Easily adaptable to various REST API testing scenarios.
- **Ready for AI**: The natural language used for describing tests is well-suited for AI-driven test generation and analysis.

## Getting Started
Assuming you prepared a Reqnroll project (see the [Quickstart](https://docs.reqnroll.net/latest/quickstart/index.html)), we need to register and prepare the project for usage with NatLaRestTest:
1. Make sure your project has a reference to [Reqnroll.NUnit](https://www.nuget.org/packages/Reqnroll.NUnit) and [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/microsoft.net.test.sdk).
2. Add a reference to the [NatLaRestTest](https://www.nuget.org/packages/NatLaRestTest.Bindings) NuGet package.
3. Make sure your test project has a reqnroll.json configuration file. It should look like this:
```
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "language": {
    "feature": "en-US"
  },
  "trace": {
    "stepDefinitionSkeletonStyle": "RegexAttribute"
  },
  "bindingAssemblies": [    
  ]
}
```
4. Add the NatLaRestTest assemblies (**both of them**) to the `bindingAssemblies` section:
```
...
"bindingAssemblies": [
    {
      "assembly": "NatLaRestTest.Core"
    },
    {
      "assembly": "NatLaRestTest.Bindings"
    }
  ]
...
```
5. Now you can start writing your tests as Reqnroll Feature files, using the NatLaRestTest bindings.

## Running tests
You can run tests created with this framework using your preferred test runner that supports NUnit, such as the built-in test explorer in Visual Studio, or via command line using the `dotnet test` command.
Currently, only NUnit is supported as the test framework.

## About variables
NatLaRestTest provides a system to work with variables in your test cases. Usage of variables in parameters (aka everything enclosed by single quotes in binding expressions) is indicated by the syntax `$(variableName)`.

Do not confuse NatLaRestTest variables with [Gherkin Scenario Outlines](https://docs.reqnroll.net/latest/gherkin/gherkin-reference.html#scenario-outline).
They are combinable, though. The Demo project provides an example for this in the `ScenarioOutlineAndExamples.feature` file.

There are several ways to define variables for usage in your tests:

### Global variables
Global variables are defined in the `globalVariables` section of your `NatLaRestTestSettings.json` configuration file. For example:
```
    "globalVariables": [
        {
          "name": "demoApiBaseUrl",
          "value": "https://localhost:7031"
        }
    ]
```

and in your test case:
```
Then the value of variable 'demoApiBaseUrl' equals 'https://localhost:7031'
```

or, as another example:

```
Given the base URL '$(demoApiBaseUrl)'
```

Global variables are available in all scenarios, and are loaded before test execution starts.

### Variable files
You can also define variables in separate JSON files, and load them during the execution of your tests using the [LoadVariablesFile](./Bindings.md#LoadVariablesFile) step binding.

For example, a file `variables.json`:
```
{
    "testVariables":[
        {
            "name": "exampleNumber",
            "value": 42
        }
    ]
}
```

Make sure this file is copied to your output directory during build (set the `Copy to Output Directory` property of the file to `Copy if newer` or `Copy always`) and load these variables during a test scenario by adding the following to your test:
```
Given the variables file 'variables.json' is loaded
Then the value of variable 'exampleNumber' equals '42'
```

### Setting variables during test execution
There are several step bindings available, which allow you to set variables during test execution, e.g. by extracting values from responses or reading a file. See the [Bindings](./Bindings.md) for more information.

### Resolving variables
As mentioned before, variables are referenced using the syntax `$(variableName)` for usage in all parameters (again, indicated by single quotes) or are asked for explicitly by specific bindings like comparisons and mutations. Consider the following example to get a feeling for the capabilities of the system:
```
When the value 'abc' is stored in variable 'firstParameter'
And the value 'def' is stored in variable 'secondParameter'
And a request to '$(firstParameter)/$(secondParameter)' is made
```
The above example will result in a request to `abc/def`.

Furthermore, variables in this syntax are resolved recursively, meaning you can have variables depending on other variables:
```
When the value 'variableValue' is stored in variable 'varName'
And the value '42' is stored in variable 'variableValue'
And the value '$($(varName))' is stored in variable 'result'
Then the value of variable 'result' equals '42'
```

## NatLaRestTestSettings.json
NatLaRestTest uses a configuration file named `NatLaRestTestSettings.json` to manage several settings.

Consider the following example:
```
{
  "additionalConfigurationFiles": [
    "./NatLaRestTestSettings.Development.json"
  ],
  "globalVariables": [
    {
      "name": "stage",
      "value": "Development"
    }
  ],
  "fileRedirects": [
    {
      "originalFileName": "settings.json",
      "redirect": "settings.$(stage).json"
    }
  ]
}
  
```

### AdditionalConfigurationFiles Block
This block allows you to specify additional configuration files to be loaded by NatLaRestTest. These files can contain environment-specific settings or overrides for the default configuration.
All files (and the default entry file) are loaded and merged together before test execution starts. In case of conflicts, the last loaded file wins, meaning that you can use this mechanism to override settings from the default configuration file.
This allows you to have both a 'NatLaRestTestSettings.json' file with default settings and additional files like 'NatLaRestTestSettings.Development.json' or 'NatLaRestTestSettings.Production.json' with environment-specific overrides, which can also be included in a .gitignore file to keep secrets like API keys from being committed.

Compare to appsettings.json files in ASP.NET Core applications, which work in a similar way.

### GlobalVariables Block
This block allows you to define global variables that can be used throughout your tests. Global variables are accessible from any test and can be used to store values that need to be shared across multiple test cases.
They are initialized before test execution starts, so they are available right from the beginning of your tests.

### FileRedirects Block
This block allows you to defined file redirects. Consider the following test case:

```
Given the variables file 'variables.json' is loaded
```

Without any file redirects, NatLaRestTest would try to load the file `variables.json` directly. However, with the following file redirect defined in the configuration file:
```
  "fileRedirects": [
    {
      "originalFileName": "variables.json",
      "redirect": "variables.$(stage).json"
    }
  ]
```
NatLaRestTest will instead try to load the file `variables.Development.json`, assuming the global variable `stage` is set to `Development`.

This allows you to easily switch between different files based on the current environment or other criteria defined by your global variables.

In contrast to the mechanism for additional configuration files, file-redirects are not additive. Meaning, no file merging takes place and only the file defined in the redirect is loaded.

## Translating into other languages
NatLaRestTest currently supports only English (en-US) as the language for writing test cases. However, since Reqnroll supports multiple languages, it is possible to translate the bindings into other languages.

NatLaRestTest was designed with localization in mind. To translate the bindings into another language, you would need to create a new set of bindings with the same functionality but with step definitions in the desired language.

See [a Proof of Concept for a German translation](./NatLaRestTest.Demo.de) (only translated a few basic bindings to demonstrate the idea) and its [underlying German bindings](./NatLaRestTest.Demo.de).

## Recommended workflow

### Using the Reqnroll IDE integrations
For an optimal experience when working with NatLaRestTest, it is recommended to use one of the Reqnroll IDE integrations, such as the [Visual Studio Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-visual-studio), the [Visual Studio Code Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-visual-studio-code) or the [JetBrains Rider Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-rider). These integrations provide features like syntax highlighting, autocompletion, and easy test execution directly from the IDE.

Also see [my Visual Studio Code Extension](https://github.com/Rotbarsch/RotbarschReqnroll-vscode) which was created with NatLaRestTest in mind, but not bound to it and should work with any Reqnroll based test suite.

### Using AI agents to generate tests
Given the natural language basis of NatLaRestTest, it is well-suited for usage with AI agents like GitHub Copilot or others. It has proven effective to "feed" either the [Bindings.md](./Bindings.md) or the `NatLaRestTest.Bindings.xml` to the agent, to familiarize it with the available step bindings. Alternatively, check out this repository and ask GitHub Copilot to create your tests using the bindings in this repository.

*Also check out another of my projects, the [ReqnRoll MCP Server](https://github.com/Rotbarsch/ReqnRoll-MCP-Server).*


## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

### Third-Party Dependencies
Information about the licenses of dependencies can be found in the [THIRD-PARTY_NOTICES.txt](./THIRD-PARTY_NOTICES.txt) file.