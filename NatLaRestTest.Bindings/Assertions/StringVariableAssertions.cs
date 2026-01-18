using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing string-related assertions on scenario variables.
/// </summary>
[Binding]
public class StringVariableAssertions : IStringVariableAssertions
{
    private readonly IStringLogic _stringLogic;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringVariableAssertions" /> class.
    /// </summary>
    /// <param name="stringLogic">Logic component for string operations.</param>
    public StringVariableAssertions(IStringLogic stringLogic)
    {
        _stringLogic = stringLogic;
    }

    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value is greater than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of variable '(.*)' is more than '(.*)' characters long")]
    public void StringVariableLengthIsMoreThan(string variableName, int length) =>
        _stringLogic.StringVariableLengthIsMoreThan(variableName, length);

    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value is less than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).
    /// </param>
    [Then("the value of variable '(.*)' is less than '(.*)' characters long")]
    public void StringVariableLengthIsLessThan(string variableName, int length) =>
        _stringLogic.StringVariableLengthIsLessThan(variableName, length);

    /// <summary>
    ///     Then step: Asserts that the length of the specified variable's string value equals the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The expected length.</param>
    [Then("the value of variable '(.*)' is '(.*)' characters long")]
    public void StringVariableLengthIs(string variableName, int length) =>
        _stringLogic.StringVariableLengthIs(variableName, length);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is not empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is not empty")]
    public void StringVariableIsNotEmpty(string variableName) =>
        _stringLogic.StringVariableIsNotEmpty(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is empty")]
    public void StringVariableIsEmpty(string variableName) =>
        _stringLogic.StringVariableIsEmpty(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value starts with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The expected prefix.</param>
    [Then("the value of variable '(.*)' starts with '(.*)'")]
    public void StringVariableStartsWith(string variableName, string prefix) =>
        _stringLogic.StringVariableStartsWith(variableName, prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value ends with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The expected suffix.</param>
    [Then("the value of variable '(.*)' ends with '(.*)'")]
    public void StringVariableEndsWith(string variableName, string suffix) =>
        _stringLogic.StringVariableEndsWith(variableName, suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not start with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The prefix that must not match.</param>
    [Then("the value of variable '(.*)' does not start with '(.*)'")]
    public void StringVariableNotStartsWith(string variableName, string prefix) =>
        _stringLogic.StringVariableNotStartsWith(variableName, prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not end with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The suffix that must not match.</param>
    [Then("the value of variable '(.*)' does not end with '(.*)'")]
    public void StringVariableNotEndsWith(string variableName, string suffix) =>
        _stringLogic.StringVariableNotEndsWith(variableName, suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value contains the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The expected substring.</param>
    [Then("the value of variable '(.*)' contains '(.*)'")]
    public void StringVariableContains(string variableName, string substring) =>
        _stringLogic.StringVariableContains(variableName, substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not contain the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The substring that must not be present.</param>
    [Then("the value of variable '(.*)' does not contain '(.*)'")]
    public void StringVariableNotContains(string variableName, string substring) =>
        _stringLogic.StringVariableNotContains(variableName, substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value equals the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The expected value.</param>
    [Then("the value of variable '(.*)' equals '(.*)'")]
    public void StringVariableEquals(string variableName, string comparison) =>
        _stringLogic.StringVariableEquals(variableName, comparison);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not equal the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The value that must not match.</param>
    [Then("the value of variable '(.*)' does not equal '(.*)'")]
    public void StringVariableNotEquals(string variableName, string comparison) =>
        _stringLogic.StringVariableNotEquals(variableName, comparison);
}