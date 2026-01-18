using System.Globalization;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides numeric operations and assertions on values stored in scenario variables.
/// </summary>
public class NumericLogic : INumericLogic
{
    private readonly INumericManipulationDriver _numericManipulationDriver;
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to access scenario variables.</param>
    /// <param name="numericManipulationDriver">Driver used to parse and manipulate numeric values.</param>
    public NumericLogic(IVariableDriver variableDriver, INumericManipulationDriver numericManipulationDriver)
    {
        _variableDriver = variableDriver;
        _numericManipulationDriver = numericManipulationDriver;
    }

    /// <summary>
    /// Adds a number to the numeric value stored in the variable.
    /// </summary>
    public void AddNumberToVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);

        var currentValue = _numericManipulationDriver.Parse(current);

        var result = currentValue + number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Multiplies the numeric value stored in the variable by the specified number.
    /// </summary>
    public void MultiplyNumberWithVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        var currentValue = _numericManipulationDriver.Parse(current);

        var result = currentValue * number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Divides the specified number by the numeric value stored in the variable.
    /// </summary>
    public void DivideNumberByVariable(double number, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        var divisor = _numericManipulationDriver.Parse(current);
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
        var dividend = _numericManipulationDriver.Parse(current);
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
        var currentValue = _numericManipulationDriver.Parse(current);
        var result = currentValue - number;
        _variableDriver.SetVariable(variableName, result.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Subtracts the numeric value stored in the variable from the provided number.
    /// </summary>
    public void SubtractVariableFromNumber(string variableName, double number)
    {
        var current = _variableDriver.GetVariable(variableName);
        var subtrahend = _numericManipulationDriver.Parse(current);
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
}