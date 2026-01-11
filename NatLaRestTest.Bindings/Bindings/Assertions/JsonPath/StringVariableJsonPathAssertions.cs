using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing string-based assertions on values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class StringVariableJsonPathAssertions
{
    private readonly IVariableDriver _variableDriver;
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringVariableJsonPathAssertions"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver dependency.</param>
    /// <param name="jsonPathDriver">The JSONPath driver for resolving values from JSON.</param>
    public StringVariableJsonPathAssertions(IVariableDriver variableDriver, IJsonPathDriver jsonPathDriver)
    {
        _variableDriver = variableDriver;
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable contains the given substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring expected to be contained.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' contains '(.*)'")]
    public void StringVariableContains(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.Contains(comparison),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' does not contain '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable does not contain the given substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring that must not be contained.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not contain '(.*)'")]
    public void StringVariableNotContains(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.Contains(comparison),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' contains '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value starts with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected prefix.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' starts with '(.*)'")]
    public void StringVariableStartsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.StartsWith(comparison), $"The value at JSONPath '{jsonPath} in variable '{variableName}' does not start with '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value does not start with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The prefix that must not match.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not start with '(.*)'")]
    public void StringVariableNotStartsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.StartsWith(comparison), $"The value at JSONPath '{jsonPath} in variable '{variableName}' starts with '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value ends with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected suffix.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' ends with '(.*)'")]
    public void StringVariableEndsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.EndsWith(comparison), $"The value at JSONPath '{jsonPath} in variable '{variableName}' does not end with '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value does not end with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The suffix that must not match.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not end with '(.*)'")]
    public void StringVariableNotEndsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.EndsWith(comparison), $"The value at JSONPath '{jsonPath} in variable '{variableName}' ends with '{comparison}'.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value length equals the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The expected length in characters.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is '(.*)' characters long")]
    public void StringVariableIsLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.AreEqual(length, value.Length, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not {length} characters long.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value is not empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is not empty")]
    public void StringVariableIsNotEmpty(string jsonPath, string variableName)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsNotEmpty(value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value is empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is empty")]
    public void StringVariableIsEmpty(string jsonPath, string variableName)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsEmpty(value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value length is greater than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is more than '(.*)' characters long")]
    public void StringVariableIsMoreThanLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.Greater(value.Length, length, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not more than {length} characters long.");
    }

    /// <summary>
    /// Then step: Asserts that the extracted value length is less than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is less than '(.*)' characters long")]
    public void StringVariableIsLessThanLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.Less(value.Length, length, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not less than {length} characters long.");
    }

    /// <summary>
    /// Resolves the value from a variable using a JSONPath expression and returns it as a string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <returns>The resolved value converted to string.</returns>
    private string GetSelectionString(string jsonPath, string variableName)
    {
        var value = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variableName), jsonPath);
        Assert.NotNull(value, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");
        return value!.ToString();
    }
}