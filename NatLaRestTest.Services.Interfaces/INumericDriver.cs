namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Provides numeric operations and assertions on variables storing numeric values.
/// </summary>
public interface INumericService
{
    /// <summary>
    /// Adds a number to the numeric value stored in the variable.
    /// </summary>
    /// <param name="number">The number to be added.</param>
    /// <param name="variableName">The name of the variable to which the number will be added.</param>
    void AddNumberToVariable(double number, string variableName);

    /// <summary>
    /// Multiplies the numeric variable value by the specified number.
    /// </summary>
    /// <param name="number">The number by which the variable value will be multiplied.</param>
    /// <param name="variableName">The name of the variable whose value will be multiplied.</param>
    void MultiplyNumberWithVariable(double number, string variableName);

    /// <summary>
    /// Divides the specified number by the numeric variable value.
    /// </summary>
    /// <param name="number">The number to be divided.</param>
    /// <param name="variableName">The name of the variable by which the number will be divided.</param>
    void DivideNumberByVariable(double number, string variableName);

    /// <summary>
    /// Divides the numeric value stored in the variable by the specified number.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be divided.</param>
    /// <param name="number">The number by which the variable value will be divided.</param>
    void DivideVariableByNumber(string variableName, double number);

    /// <summary>
    /// Subtracts a number from the numeric value stored in the variable.
    /// </summary>
    /// <param name="number">The number to be subtracted.</param>
    /// <param name="variableName">The name of the variable from which the number will be subtracted.</param>
    void SubtractNumberFromVariable(double number, string variableName);

    /// <summary>
    /// Subtracts the numeric value stored in the variable from the provided number.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be subtracted.</param>
    /// <param name="number">The number from which the variable value will be subtracted.</param>
    void SubtractVariableFromNumber(string variableName, double number);

    /// <summary>
    /// Asserts that the numeric value stored in the variable is greater than the provided value.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be compared.</param>
    /// <param name="value">The value to compare against.</param>
    void NumericVariableIsGreaterThan(string variableName, double value);

    /// <summary>
    /// Asserts that the numeric value stored in the variable is less than the provided value.
    /// </summary>
    void NumericVariableIsLessThan(string variableName, double value);

    bool ParseNumber(string? input, out double parsed);
}