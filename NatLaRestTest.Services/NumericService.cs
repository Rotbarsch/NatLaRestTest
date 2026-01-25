using System.Globalization;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
/// Provides numeric operations and assertions on values stored in scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NumericService"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
public class NumericService(IVariableService variableService) : INumericService
{

    public void Addition(string summand1, string summand2, string targetVariableName)
    {
        Assert.IsTrue(ParseNumber(summand1, out var s1), $"Failed to parse '{summand1}' as a number.");
        Assert.IsTrue(ParseNumber(summand2, out var s2), $"Failed to parse '{summand2}' as a number.");

        variableService.SetVariable(targetVariableName, (s1 + s2).ToString(CultureInfo.InvariantCulture));
    }

    public void Subtraction(string minuend, string subtrahend, string targetVariableName)
    {
        Assert.IsTrue(ParseNumber(minuend, out var m), $"Failed to parse '{minuend}' as a number.");
        Assert.IsTrue(ParseNumber(subtrahend, out var s), $"Failed to parse '{subtrahend}' as a number.");
        variableService.SetVariable(targetVariableName, (m - s).ToString(CultureInfo.InvariantCulture));
    }

    public void Multiplication(string factor1, string factor2, string targetVariableName)
    {
        Assert.IsTrue(ParseNumber(factor1, out var f1), $"Failed to parse '{factor1}' as a number.");
        Assert.IsTrue(ParseNumber(factor2, out var f2), $"Failed to parse '{factor2}' as a number.");

        variableService.SetVariable(targetVariableName, (f1 * f2).ToString(CultureInfo.InvariantCulture));
    }

    public void Division(string dividend, string divisor, string targetVariableName)
    {
        Assert.IsTrue(ParseNumber(dividend, out var d), $"Failed to parse '{dividend}' as a number.");
        Assert.IsTrue(ParseNumber(divisor, out var di), $"Failed to parse '{divisor}' as a number.");

        variableService.SetVariable(targetVariableName, (d / di).ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Asserts that the numeric value stored in the variable is greater than the provided value.
    /// </summary>
    public void NumericVariableIsGreaterThan(string variableName, double value)
    {
        var actualValue = variableService.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");
        
        Assert.IsTrue(ParseNumber(actualValue, out var parsed), $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Greater(parsed, value, $"The value in variable '{variableName}' is not more than {value}.");
    }

    /// <summary>
    /// Asserts that the numeric value stored in the variable is less than the provided value.
    /// </summary>
    public void NumericVariableIsLessThan(string variableName, double value)
    {
        var actualValue = variableService.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");

        Assert.IsTrue(ParseNumber(actualValue, out var parsed), $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Less(parsed, value, $"The value in variable '{variableName}' is not less than {value}.");
    }

    public bool ParseNumber(string? input, out double parsed)
    {
        Assert.NotNull(input, "Cannot parse null.");
        return double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out parsed);
    }
}