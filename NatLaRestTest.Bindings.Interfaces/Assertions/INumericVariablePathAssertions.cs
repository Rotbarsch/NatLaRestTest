namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface INumericVariableAssertions
{
    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void NumericVariableIsGreaterThan(string variableName, int value);

    /// <summary>
    ///     Then step: Asserts that the numeric value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void NumericVariableIsLessThan(string variableName, int value);
}