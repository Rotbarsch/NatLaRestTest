namespace NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;

public interface INumericVariableJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is greater than the
    ///     given value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void NumericVariableIsGreaterThan(string jsonPath, string variableName, int value);

    /// <summary>
    ///     Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is less than the given
    ///     value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    void NumericVariableIsLessThan(string jsonPath, string variableName, int value);
}