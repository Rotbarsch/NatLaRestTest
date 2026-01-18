namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface IStringVariableAssertions
{
    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value is greater than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    void StringVariableLengthIsMoreThan(string variableName, int length);

    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value is less than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    void StringVariableLengthIsLessThan(string variableName, int length);

    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value equals the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The expected length.</param>
    void StringVariableLengthIs(string variableName, int length);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is not empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    void StringVariableIsNotEmpty(string variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    void StringVariableIsEmpty(string variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value starts with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The expected prefix.</param>
    void StringVariableStartsWith(string variableName, string prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value ends with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The expected suffix.</param>
    void StringVariableEndsWith(string variableName, string suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not start with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The prefix that must not match.</param>
    void StringVariableNotStartsWith(string variableName, string prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not end with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The suffix that must not match.</param>
    void StringVariableNotEndsWith(string variableName, string suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value contains the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The expected substring.</param>
    void StringVariableContains(string variableName, string substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not contain the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The substring that must not be present.</param>
    void StringVariableNotContains(string variableName, string substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value equals the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The expected value.</param>
    void StringVariableEquals(string variableName, string comparison);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not equal the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The value that must not match.</param>
    void StringVariableNotEquals(string variableName, string comparison);
}