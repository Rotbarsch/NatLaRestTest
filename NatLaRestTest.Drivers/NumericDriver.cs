using System.Globalization;
using NatLaRestTest.Drivers.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides numeric operations and assertions on values stored in scenario variables.
/// </summary>
public class NumericDriver : INumericDriver
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericDriver"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to access scenario variables.</param>
    public NumericDriver(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Adds a number to the numeric value stored in the variable.
    /// </summary>
    public void AddNumberToVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);

        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");

        var result = currentValue + number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Multiplies the numeric value stored in the variable by the specified number.
    /// </summary>
    public void MultiplyNumberWithVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");

        var result = currentValue * number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Divides the specified number by the numeric value stored in the variable.
    /// </summary>
    public void DivideNumberByVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var divisor), $"Value '{current}' of variable {variableName} is not a parsable number.");
        Assert.AreNotEqual(0d, divisor, $"Division by zero for variable '{variableName}'.");
        var result = number / divisor;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Divides the numeric value stored in the variable by the specified number.
    /// </summary>
    public void DivideVariableByNumber(string variableName, double number)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var dividend), $"Value '{current}' of variable {variableName} is not a parsable number.");
        Assert.AreNotEqual(0d, number, "Division by zero.");
        var result = dividend / number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Subtracts a number from the numeric value stored in the variable.
    /// </summary>
    public void SubtractNumberFromVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var currentValue), $"Value '{current}' of variable {variableName} is not a parsable number.");
        var result = currentValue - number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Subtracts the numeric value stored in the variable from the provided number.
    /// </summary>
    public void SubtractVariableFromNumber(string variableName, double number)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.IsTrue(ParseNumber(current, out var subtrahend), $"Value '{current}' of variable {variableName} is not a parsable number.");
        var result = number - subtrahend;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Asserts that the numeric value stored in the variable is greater than the provided value.
    /// </summary>
    public void NumericVariableIsGreaterThan(string variableName, int value)
    {
        var actualValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");

        Assert.IsTrue(
            double.TryParse(actualValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture,
                out var parsed),
            $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Greater(parsed, value, $"The value in variable '{variableName}' is not more than {value}.");
    }

    /// <summary>
    /// Asserts that the numeric value stored in the variable is less than the provided value.
    /// </summary>
    public void NumericVariableIsLessThan(string variableName, int value)
    {
        var actualValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(actualValue, $"Variable '{variableName}' returned null.");

        Assert.IsTrue(
            double.TryParse(actualValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture,
                out var parsed),
            $"Variable '{variableName}' does not contain a numeric value. Actual: '{actualValue}'.");

        Assert.Less(parsed, value, $"The value in variable '{variableName}' is not less than {value}.");
    }

    public bool ParseNumber(string? input, out double parsed)
    {
        Assert.NotNull(input, "Cannot parse null.");
        return double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out parsed);
    }
}