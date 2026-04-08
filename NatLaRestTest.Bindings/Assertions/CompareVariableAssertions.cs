using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Core.Contracts;
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
public class CompareVariableAssertions(IComparisonService comparisonService, IVariableService variableService) : ICompareVariableAssertions
{

    /// <summary>
    ///     Then step: Asserts that the numeric or date value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric or date value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of variable '(.*)' is greater than '(.*)'")]
    public void VariableIsGreaterThan(string variableName, string? value)
    {
        comparisonService.Compare(variableService.GetVariable(variableName), ComparisonOperation.GreaterThan, value);
    }

    /// <summary>
    ///     Then step: Asserts that the numeric or date value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric or date value.</param>
    /// <param name="value">The threshold value (exclusive).
    /// </param>
    [Then("the value of variable '(.*)' is less than '(.*)'")]
    public void VariableIsLessThan(string variableName, string? value)
    {
        comparisonService.Compare(variableService.GetVariable(variableName), ComparisonOperation.LessThan, value);
    }
}