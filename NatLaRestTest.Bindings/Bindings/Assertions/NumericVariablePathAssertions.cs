using System.Globalization;
using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing numeric assertions on variables that store numeric values.
/// </summary>
[Binding]
public class NumericVariablePathAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Step bindings providing numeric assertions on variables that store numeric values.
    /// </summary>
    public NumericVariablePathAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of variable '(.*)' is greater than '(.*)'")]
    public void NumericVariableIsGreaterThan(string variableName, int value)
    {
        var actualValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");

        Assert.IsTrue(double.TryParse(actualValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var parsed),
            $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Greater(parsed, value, $"The value in variable '{variableName}' is not more than {value}.");
    }

    /// <summary>
    /// Then step: Asserts that the numeric value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of variable '(.*)' is less than '(.*)'")]
    public void NumericVariableIsLessThan(string variableName, int value)
    {
        var actualValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");

        Assert.IsTrue(double.TryParse(actualValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var parsed),
            $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Less(parsed, value, $"The value in variable '{variableName}' is not less than {value}.");
    }
}