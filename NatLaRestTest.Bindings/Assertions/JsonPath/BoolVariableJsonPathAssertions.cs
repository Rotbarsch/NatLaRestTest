using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing boolean assertions on values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class BoolVariableJsonPathAssertions(IJsonPathLogic jsonPathLogic) : IBoolVariableJsonPathAssertions
{
    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable is true.
    /// Example usage: Then the value of JSONPath '$.active' in variable 'responseBody' is true
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is true")]
    public void AssertJsonPathReturnsTrue(string jsonPath, string variableName)
    {
        jsonPathLogic.AssertJsonPathReturnsBoolean(variableName, jsonPath, true);
    }

    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable is false.
    /// Example usage: Then the value of JSONPath '$.feature.enabled' in variable 'responseBody' is false
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is false")]
    public void AssertJsonPathReturnsFalse(string jsonPath, string variableName)
    {
        jsonPathLogic.AssertJsonPathReturnsBoolean(variableName, jsonPath, false);
    }
}