namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Provides numeric operations and assertions on variables storing numeric values.
/// </summary>
public interface INumericService
{
    /// <summary>
    /// Adds two numbers and stores the result in a variable.
    /// </summary>
    /// <param name="summand1">Summand.</param>
    /// <param name="summand2">Summand.</param>
    /// <param name="targetVariableName">Name of the target variable.</param>
    void Addition(string summand1, string summand2, string targetVariableName);

    /// <summary>
    /// Subtracts one number from another and stores the result in a variable.
    /// </summary>
    /// <param name="minuend">Minuend.</param>
    /// <param name="subtrahend">Subtrahend.</param>
    /// <param name="targetVariableName">Name of the target variable.</param>
    void Subtraction(string minuend, string subtrahend, string targetVariableName);

    /// <summary>
    /// Multiplies one number with another and stores the result in a variable.
    /// </summary>
    /// <param name="factor1">Factor 1.</param>
    /// <param name="factor2">Factor 2.</param>
    /// <param name="targetVariableName">Name of the target variable.</param>
    void Multiplication(string factor1, string factor2, string targetVariableName);

    /// <summary>
    /// Divides one number by another and stores the result in a variable.
    /// </summary>
    /// <param name="dividend">Dividend.</param>
    /// <param name="divisor">Divisor.</param>
    /// <param name="targetVariableName">Name of the target variable.</param>
    void Division(string dividend, string divisor, string targetVariableName);

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