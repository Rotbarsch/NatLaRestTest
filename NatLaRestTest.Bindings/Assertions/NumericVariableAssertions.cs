using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing numeric assertions on variables that store numeric values.
/// </summary>
[Binding]
public class NumericVariableAssertions : INumericVariableAssertions
{
    private readonly INumericDriver _numericDriver;

    /// <summary>
    ///     Step bindings providing numeric assertions on variables that store numeric values.
    /// </summary>
    public NumericVariableAssertions(INumericDriver numericDriver)
    {
        _numericDriver = numericDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of variable '(.*)' is greater than '(.*)'")]
    public void NumericVariableIsGreaterThan(string variableName, int value)
    {
        _numericDriver.NumericVariableIsGreaterThan(variableName, value);
    }

    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).
    /// </param>
    [Then("the value of variable '(.*)' is less than '(.*)'")]
    public void NumericVariableIsLessThan(string variableName, int value)
    {
        _numericDriver.NumericVariableIsLessThan(variableName, value);
    }
}