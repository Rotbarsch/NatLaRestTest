using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing numeric assertions on variables that store numeric values.
/// </summary>
/// <remarks>
///     Step bindings providing numeric assertions on variables that store numeric values.
/// </remarks>
[Binding]
public class NumericVariableAssertions(INumericService numericService) : INumericVariableAssertions
{

    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of variable '(.*)' is greater than '(.*)'")]
    public void NumericVariableIsGreaterThan(string variableName, double value)
    {
        numericService.NumericVariableIsGreaterThan(variableName, value);
    }

    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).
    /// </param>
    [Then("the value of variable '(.*)' is less than '(.*)'")]
    public void NumericVariableIsLessThan(string variableName, double value)
    {
        numericService.NumericVariableIsLessThan(variableName, value);
    }
}