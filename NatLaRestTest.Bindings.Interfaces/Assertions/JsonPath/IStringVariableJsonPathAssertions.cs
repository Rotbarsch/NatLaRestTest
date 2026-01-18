namespace NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;

public interface IStringVariableJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value extracted by JSONPath from the specified variable contains the given substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring expected to be contained.</param>
    void StringVariableContains(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the value extracted by JSONPath from the specified variable does not contain the given
    ///     substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring that must not be contained.</param>
    void StringVariableNotContains(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the extracted value starts with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected prefix.</param>
    void StringVariableStartsWith(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the extracted value does not start with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The prefix that must not match.</param>
    void StringVariableNotStartsWith(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the extracted value ends with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected suffix.</param>
    void StringVariableEndsWith(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the extracted value does not end with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The suffix that must not match.</param>
    void StringVariableNotEndsWith(string jsonPath, string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the extracted value length equals the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The expected length in characters.</param>
    void StringVariableIsLength(string jsonPath, string variableName, int length);

    /// <summary>
    ///     Then step: Asserts that the extracted value is not empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    void StringVariableIsNotEmpty(string jsonPath, string variableName);

    /// <summary>
    ///     Then step: Asserts that the extracted value is empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    void StringVariableIsEmpty(string jsonPath, string variableName);

    /// <summary>
    ///     Then step: Asserts that the extracted value length is greater than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    void StringVariableIsMoreThanLength(string jsonPath, string variableName, int length);

    /// <summary>
    ///     Then step: Asserts that the extracted value length is less than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    void StringVariableIsLessThanLength(string jsonPath, string variableName, int length);
}