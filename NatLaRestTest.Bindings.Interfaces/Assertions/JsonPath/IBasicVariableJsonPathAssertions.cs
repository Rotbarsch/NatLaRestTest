namespace NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;

public interface IBasicVariableJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable equals the given
    ///     comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The expected string value to compare against the selected value.</param>
    void AssertValueEquals(string jsonPath, string variable, string comparison);

    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable does not equal the
    ///     given comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The string value that must not match the selected value.</param>
    void AssertValueNotEquals(string jsonPath, string variable, string comparison);

    /// <summary>
    ///     Then step: Asserts that the provided JSONPath in the specified variable returns any value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    void AssertJsonPathReturnsAnyValue(string jsonPath, string variable);
}