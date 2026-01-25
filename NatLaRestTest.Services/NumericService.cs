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

    /// <summary>
    /// Adds a number to the numeric value stored in the variable.
    /// </summary>
    public void AddNumberToVariable(double number, string variableName)
    {
        var current = variableService.GetVariable(variableName);

        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");

        var result = currentValue + number;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Multiplies the numeric value stored in the variable by the specified number.
    /// </summary>
    public void MultiplyNumberWithVariable(double number, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");

        var result = currentValue * number;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Divides the specified number by the numeric value stored in the variable.
    /// </summary>
    public void DivideNumberByVariable(double number, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var divisor), $"Value '{current}' of variable {variableName} is not a parsable number.");
        Assert.AreNotEqual(0d, divisor, $"Division by zero for variable '{variableName}'.");
        var result = number / divisor;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Divides the numeric value stored in the variable by the specified number.
    /// </summary>
    public void DivideVariableByNumber(string variableName, double number)
    {
        var current = variableService.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var dividend), $"Value '{current}' of variable {variableName} is not a parsable number.");
        Assert.AreNotEqual(0d, number, "Division by zero.");
        var result = dividend / number;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Subtracts a number from the numeric value stored in the variable.
    /// </summary>
    public void SubtractNumberFromVariable(double number, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");
        var result = currentValue - number;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Subtracts the numeric value stored in the variable from the provided number.
    /// </summary>
    public void SubtractVariableFromNumber(string variableName, double number)
    {
        var current = variableService.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var subtrahend), $"Value '{current}' of variable {variableName} is not a parsable number.");
        var result = number - subtrahend;
        variableService.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
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