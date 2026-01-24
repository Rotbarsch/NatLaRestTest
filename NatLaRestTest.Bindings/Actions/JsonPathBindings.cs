using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for extracting values from JSON variables using JSONPath and storing them in scenario variables.
/// </summary>
[Binding]
public class JsonPathBindings : IJsonPathBindings
{
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonPathBindings" /> class.
    /// </summary>
    /// <param name="jsonPathDriver">Driver component used to evaluate JSONPath and set variables.</param>
    public JsonPathBindings(IJsonPathDriver jsonPathDriver)
    {
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    ///     When step: Extracts a value from a JSON variable via JSONPath and stores it as a new variable (stringified).
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    /// <param name="targetVariableName">The name of the variable to set with the extracted value.</param>
    [When("the value of JSONPath '(.*)' in variable '(.*)' is stored in variable '(.*)'")]
    public void SetVariableFromJsonPath(string jPath, string sourceVariableName, string targetVariableName)
    {
        _jsonPathDriver.SetVariableFromJPath(jPath, sourceVariableName, targetVariableName);
    }
}