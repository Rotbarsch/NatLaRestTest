using System.Globalization;
using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class NumericVariableJsonPathAssertions
{
    private readonly IVariableDriver _variableDriver;
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    /// Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
    /// </summary>
    public NumericVariableJsonPathAssertions(IVariableDriver variableDriver, IJsonPathDriver jsonPathDriver)
    {
        _variableDriver = variableDriver;
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    /// Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is greater than the given value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is greater than '(.*)'")]
    public void NumericVariableIsGreaterThan(string jsonPath, string variableName, int value)
    {
        var actualValue = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variableName), jsonPath);
        Assert.NotNull(actualValue, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");

        var str = actualValue!.ToString();
        Assert.IsTrue(double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var parsed),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not numeric. Actual: '{str}'.");

        Assert.Greater(parsed, value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not more than {value}.");
    }

    /// <summary>
    /// Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is less than the given value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is less than '(.*)'")]
    public void NumericVariableIsLessThan(string jsonPath, string variableName, int value)
    {
        var actualValue = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variableName), jsonPath);
        Assert.NotNull(actualValue, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");

        var str = actualValue!.ToString();
        Assert.IsTrue(double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var parsed),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not numeric. Actual: '{str}'.");

        Assert.Less(parsed, value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not less than {value}.");
    }
}