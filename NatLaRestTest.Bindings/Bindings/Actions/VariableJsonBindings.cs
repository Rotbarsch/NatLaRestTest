using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for extracting values from JSON variables using JSONPath and storing them in scenario variables.
/// </summary>
[Binding]
public class VariableJsonBindings
{
    private readonly IVariableDriver _variableDriver;
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    /// Step bindings for extracting values from JSON variables using JSONPath and storing them in scenario variables.
    /// </summary>
    public VariableJsonBindings(IVariableDriver variableDriver, IJsonPathDriver jsonPathDriver)
    {
        _variableDriver = variableDriver;
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    /// When step: Extracts a value from a JSON variable via JSONPath and stores it as a new variable (stringified).
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    /// <param name="targetVariableName">The name of the variable to set with the extracted value.</param>
    [When("the value of JSONPath '(.*)' in variable '(.*)' is stored in variable '(.*)'")]
    public void SetVariableFromJPath(string jPath, string sourceVariableName, string targetVariableName)
    {
        var selection = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(sourceVariableName), jPath);
        _variableDriver.SetVariable(targetVariableName, selection?.ToString());
    }
}