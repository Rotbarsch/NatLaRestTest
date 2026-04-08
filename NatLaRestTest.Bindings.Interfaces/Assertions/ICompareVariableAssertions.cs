namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface ICompareVariableAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value stored in the specified variable is greater than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void VariableIsGreaterThan(string variableName, string? value);

    /// <summary>
    ///     Then step: Asserts that the value stored in the specified variable is less than the given value.
    /// </summary>
    /// <param name="variableName">The variable name containing a numeric value.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void VariableIsLessThan(string variableName, string? value);
}