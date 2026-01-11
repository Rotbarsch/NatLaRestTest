using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a JSON variable.
/// </summary>
[Binding]
public class BasicVariableJsonPathAssertions
{
    private readonly IVariableDriver _variableDriver;
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    /// Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a JSON variable.
    /// </summary>
    public BasicVariableJsonPathAssertions(IVariableDriver variableDriver, IJsonPathDriver jsonPathDriver)
    {
        _variableDriver = variableDriver;
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    /// Then step: Asserts that the value selected by the provided JSONPath from the specified variable equals the given comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The expected string value to compare against the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' equals '(.*)'")]
    public void AssertValueEquals(string jsonPath, string variable, string comparison)
    {
        var selection = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variable), jsonPath);
        Assert.AreEqual(comparison, selection?.ToString(), $"The value at JSONPath '{jsonPath}' in variable '{variable}' does not equal '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the value selected by the provided JSONPath from the specified variable does not equal the given comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The string value that must not match the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not equal '(.*)'")]
    public void AssertValueNotEquals(string jsonPath, string variable, string comparison)
    {
        var selection = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variable), jsonPath);
        Assert.AreNotEqual(comparison, selection?.ToString(), $"The value at JSONPath '{jsonPath}' in variable '{variable}' equals '{comparison}'.");
    }
}