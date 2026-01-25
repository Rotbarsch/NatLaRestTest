using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides operations to manipulate and assert on string values stored in scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="StringDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
public class StringDriver(IVariableService variableService) : IStringDriver
{

    /// <summary>
    /// Appends the provided string to the value in the specified variable.
    /// </summary>
    public void AppendStringToVariable(string valueToAppend, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        variableService.SetVariable(variableName, current + valueToAppend);
    }

    /// <summary>
    /// Prepends the provided string to the value in the specified variable.
    /// </summary>
    public void PrependStringToVariable(string valueToPrepend, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        variableService.SetVariable(variableName, valueToPrepend + current);
    }

    /// <summary>
    /// Replaces occurrences of <paramref name="oldValue"/> with <paramref name="newValue"/> in the variable's value.
    /// </summary>
    public void ReplaceStringInVariable(string oldValue, string newValue, string variableName)
    {
        var current = variableService.GetVariable(variableName);
        Assert.NotNull(current);
        variableService.SetVariable(variableName, current!.Replace(oldValue, newValue));
    }

    /// <summary>
    /// Asserts that the variable's string length is greater than the provided value.
    /// </summary>
    public void StringVariableLengthIsMoreThan(string variableName, int length)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.Greater(value!.Length, length,
            $"The length of variable '{variableName}' is not more than {length} characters.");
    }

    /// <summary>
    /// Asserts that the variable's string length is less than the provided value.
    /// </summary>
    public void StringVariableLengthIsLessThan(string variableName, int length)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.Less(value!.Length, length,
            $"The length of variable '{variableName}' is not less than {length} characters.");
    }

    /// <summary>
    /// Asserts that the variable's string length equals the provided value.
    /// </summary>
    public void StringVariableLengthIs(string variableName, int length)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreEqual(length, value!.Length, $"The length of variable '{variableName}' is not {length} characters.");
    }

    /// <summary>
    /// Asserts that the variable's string is not empty.
    /// </summary>
    public void StringVariableIsNotEmpty(string variableName)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsNotEmpty(value!, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Asserts that the variable's string is empty.
    /// </summary>
    public void StringVariableIsEmpty(string variableName)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsEmpty(value!, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Asserts that the variable's string starts with the provided prefix.
    /// </summary>
    public void StringVariableStartsWith(string variableName, string prefix)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.StartsWith(prefix), $"Variable '{variableName}' does not start with '{prefix}'.");
    }

    /// <summary>
    /// Asserts that the variable's string ends with the provided suffix.
    /// </summary>
    public void StringVariableEndsWith(string variableName, string suffix)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.EndsWith(suffix), $"Variable '{variableName}' does not end with '{suffix}'.");
    }

    /// <summary>
    /// Asserts that the variable's string does not start with the provided prefix.
    /// </summary>
    public void StringVariableNotStartsWith(string variableName, string prefix)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.StartsWith(prefix), $"Variable '{variableName}' starts with '{prefix}'.");
    }

    /// <summary>
    /// Asserts that the variable's string does not end with the provided suffix.
    /// </summary>
    public void StringVariableNotEndsWith(string variableName, string suffix)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.EndsWith(suffix), $"Variable '{variableName}' ends with '{suffix}'.");
    }

    /// <summary>
    /// Asserts that the variable's string contains the provided substring.
    /// </summary>
    public void StringVariableContains(string variableName, string substring)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsTrue(value!.Contains(substring), $"Variable '{variableName}' does not contain '{substring}'.");
    }

    /// <summary>
    /// Asserts that the variable's string does not contain the provided substring.
    /// </summary>
    public void StringVariableNotContains(string variableName, string substring)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.IsFalse(value!.Contains(substring), $"Variable '{variableName}' contains '{substring}'.");
    }

    /// <summary>
    /// Asserts that the variable's string equals the provided comparison value.
    /// </summary>
    public void StringVariableEquals(string variableName, string comparison)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreEqual(comparison, value!, $"Variable '{variableName}' does not equal '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the variable's string does not equal the provided comparison value.
    /// </summary>
    public void StringVariableNotEquals(string variableName, string comparison)
    {
        var value = variableService.GetVariable(variableName);
        Assert.NotNull(value, $"Variable '{variableName}' is null.");
        Assert.AreNotEqual(comparison, value!, $"Variable '{variableName}' equals '{comparison}'.");
    }

    /// <summary>
    /// Stores a substring of the input string into the target variable.
    /// </summary>
    /// <param name="startIndex">Starting index of the substring.</param>
    /// <param name="length">Length of the substring.</param>
    /// <param name="input">Source string.</param>
    /// <param name="targetVariableName">Target variable to store the substring.</param>
    public void GetSubString(int startIndex, int length, string input, string targetVariableName)
    {
        var substring = input.Substring(startIndex, length);
        variableService.SetVariable(targetVariableName, substring);
    }

    /// <summary>
    /// Stores the length of the input string into the target variable.
    /// </summary>
    /// <param name="input">Source string.</param>
    /// <param name="targetVariableName">Target variable to store the length value.</param>
    public void GetStringLength(string input, string targetVariableName)
    {
        var stringLength = input.Length;
        variableService.SetVariable(targetVariableName, stringLength.ToString());
    }
}