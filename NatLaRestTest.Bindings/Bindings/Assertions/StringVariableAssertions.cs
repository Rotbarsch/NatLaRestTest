using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing string-related assertions on scenario variables.
/// </summary>
[Binding]
public class StringVariableAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringVariableAssertions"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver dependency.</param>
    public StringVariableAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the length of the specified variable's string value is greater than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of variable '(.*)' is more than '(.*)' characters long")]
    public void StringVariableLengthIsMoreThan(string variableName, int length)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.Greater(value!.Length, length, $"The length of variable '{variableName}' is not more than {length} characters.");
    }

    /// <summary>
    /// Then step: Asserts that the length of the specified variable's string value is less than the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of variable '(.*)' is less than '(.*)' characters long")]
    public void StringVariableLengthIsLessThan(string variableName, int length)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.Less(value!.Length, length, $"The length of variable '{variableName}' is not less than {length} characters.");
    }

    /// <summary>
    /// Then step: Asserts that the length of the specified variable's string value equals the given length.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="length">The expected length.</param>
    [Then("the value of variable '(.*)' is '(.*)' characters long")]
    public void StringVariableLengthIs(string variableName, int length)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreEqual(length, value!.Length, $"The length of variable '{variableName}' is not {length} characters.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value is not empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is not empty")]
    public void StringVariableIsNotEmpty(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsNotEmpty(value!, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value is empty.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    [Then("the value of variable '(.*)' is empty")]
    public void StringVariableIsEmpty(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsEmpty(value!, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value starts with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The expected prefix.</param>
    [Then("the value of variable '(.*)' starts with '(.*)'")]
    public void StringVariableStartsWith(string variableName, string prefix)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.StartsWith(prefix), $"Variable '{variableName}' does not start with '{prefix}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value ends with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The expected suffix.</param>
    [Then("the value of variable '(.*)' ends with '(.*)'")]
    public void StringVariableEndsWith(string variableName, string suffix)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.EndsWith(suffix), $"Variable '{variableName}' does not end with '{suffix}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value does not start with the given prefix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="prefix">The prefix that must not match.</param>
    [Then("the value of variable '(.*)' does not start with '(.*)'")]
    public void StringVariableNotStartsWith(string variableName, string prefix)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.StartsWith(prefix), $"Variable '{variableName}' starts with '{prefix}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value does not end with the given suffix.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="suffix">The suffix that must not match.</param>
    [Then("the value of variable '(.*)' does not end with '(.*)'")]
    public void StringVariableNotEndsWith(string variableName, string suffix)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.EndsWith(suffix), $"Variable '{variableName}' ends with '{suffix}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value contains the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The expected substring.</param>
    [Then("the value of variable '(.*)' contains '(.*)'")]
    public void StringVariableContains(string variableName, string substring)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.Contains(substring), $"Variable '{variableName}' does not contain '{substring}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value does not contain the given substring.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="substring">The substring that must not be present.</param>
    [Then("the value of variable '(.*)' does not contain '(.*)'")]
    public void StringVariableNotContains(string variableName, string substring)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.Contains(substring), $"Variable '{variableName}' contains '{substring}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value equals the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The expected value.</param>
    [Then("the value of variable '(.*)' equals '(.*)'")]
    public void StringVariableEquals(string variableName, string comparison)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreEqual(comparison, value!, $"Variable '{variableName}' does not equal '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable's string value does not equal the given comparison string.
    /// </summary>
    /// <param name="variableName">The variable to inspect.</param>
    /// <param name="comparison">The value that must not match.</param>
    [Then("the value of variable '(.*)' does not equal '(.*)'")]
    public void StringVariableNotEquals(string variableName, string comparison)
    {
        var value = _variableDriver.GetVariable(variableName)?.ToString();
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreNotEqual(comparison, value!, $"Variable '{variableName}' equals '{comparison}'.");
    }

}