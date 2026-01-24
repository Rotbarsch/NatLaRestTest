using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing string-related assertions on scenario variables.
/// </summary>
[Binding]
public class StringVariableAssertions : IStringVariableAssertions
{
    private readonly IStringDriver _stringDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringVariableAssertions" /> class.
    /// </summary>
    /// <param name="stringDriver">Driver component for string operations.</param>
    public StringVariableAssertions(IStringDriver stringDriver)
    {
        _stringDriver = stringDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is not empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is not empty")]
    public void StringVariableIsNotEmpty(string variableName) =>
        _stringDriver.StringVariableIsNotEmpty(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value is empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is empty")]
    public void StringVariableIsEmpty(string variableName) =>
        _stringDriver.StringVariableIsEmpty(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value starts with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The expected prefix.</param>
    [Then("the value of variable '(.*)' starts with:")]
    [Then("the value of variable '(.*)' starts with '(.*)'")]
    public void StringVariableStartsWith(string variableName, string prefix) =>
        _stringDriver.StringVariableStartsWith(variableName, prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value ends with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The expected suffix.</param>
    [Then("the value of variable '(.*)' ends with:")]
    [Then("the value of variable '(.*)' ends with '(.*)'")]
    public void StringVariableEndsWith(string variableName, string suffix) =>
        _stringDriver.StringVariableEndsWith(variableName, suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not start with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The prefix that must not match.</param>
    [Then("the value of variable '(.*)' does not start with:")]
    [Then("the value of variable '(.*)' does not start with '(.*)'")]
    public void StringVariableNotStartsWith(string variableName, string prefix) =>
        _stringDriver.StringVariableNotStartsWith(variableName, prefix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not end with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The suffix that must not match.</param>
    [Then("the value of variable '(.*)' does not end with:")]
    [Then("the value of variable '(.*)' does not end with '(.*)'")]
    public void StringVariableNotEndsWith(string variableName, string suffix) =>
        _stringDriver.StringVariableNotEndsWith(variableName, suffix);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value contains the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The expected substring.</param>
    [Then("the value of variable '(.*)' contains:")]
    [Then("the value of variable '(.*)' contains '(.*)'")]
    public void StringVariableContains(string variableName, string substring) =>
        _stringDriver.StringVariableContains(variableName, substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not contain the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The substring that must not be present.</param>
    [Then("the value of variable '(.*)' does not contain:")]
    [Then("the value of variable '(.*)' does not contain '(.*)'")]
    public void StringVariableNotContains(string variableName, string substring) =>
        _stringDriver.StringVariableNotContains(variableName, substring);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value equals the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The expected value.</param>
    [Then("the value of variable '(.*)' equals:")]
    [Then("the value of variable '(.*)' equals '(.*)'")]
    public void StringVariableEquals(string variableName, string comparison) =>
        _stringDriver.StringVariableEquals(variableName, comparison);

    /// <summary>
    ///     Then step: Asserts that the specified variable's string value does not equal the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The value that must not match.</param>
    [Then("the value of variable '(.*)' does not equal:")]
    [Then("the value of variable '(.*)' does not equal '(.*)'")]
    public void StringVariableNotEquals(string variableName, string comparison) =>
        _stringDriver.StringVariableNotEquals(variableName, comparison);
}