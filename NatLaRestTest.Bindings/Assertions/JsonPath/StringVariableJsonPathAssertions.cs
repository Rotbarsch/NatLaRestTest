using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing string-based assertions on values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class StringVariableJsonPathAssertions(IJsonPathDriver jsonPathDriver) : IStringVariableJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value extracted by JSONPath from the specified variable contains the given substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring expected to be contained.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' contains:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' contains '(.*)'")]
    public void StringVariableContains(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableContains(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the value extracted by JSONPath from the specified variable does not contain the given
    ///     substring.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The substring that must not be contained.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not contain:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not contain '(.*)'")]
    public void StringVariableNotContains(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableNotContains(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value starts with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected prefix.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' starts with:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' starts with '(.*)'")]
    public void StringVariableStartsWith(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableStartsWith(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value does not start with the specified prefix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The prefix that must not match.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not start with:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not start with '(.*)'")]
    public void StringVariableNotStartsWith(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableNotStartsWith(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value ends with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The expected suffix.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' ends with:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' ends with '(.*)'")]
    public void StringVariableEndsWith(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableEndsWith(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value does not end with the specified suffix.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="comparison">The suffix that must not match.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not end with:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not end with '(.*)'")]
    public void StringVariableNotEndsWith(string jsonPath, string variableName, string comparison)
    {
        jsonPathDriver.StringVariableNotEndsWith(jsonPath, variableName, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value length equals the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The expected length in characters.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is '(.*)' characters long")]
    public void StringVariableIsLength(string jsonPath, string variableName, int length)
    {
        jsonPathDriver.StringVariableIsLength(jsonPath, variableName, length);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value is not empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is not empty")]
    public void StringVariableIsNotEmpty(string jsonPath, string variableName)
    {
        jsonPathDriver.StringVariableIsNotEmpty(jsonPath, variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value is empty.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is empty")]
    public void StringVariableIsEmpty(string jsonPath, string variableName)
    {
        jsonPathDriver.StringVariableIsEmpty(jsonPath, variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value length is greater than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is more than '(.*)' characters long")]
    public void StringVariableIsMoreThanLength(string jsonPath, string variableName, int length)
    {
        jsonPathDriver.StringVariableIsMoreThanLength(jsonPath, variableName, length);
    }

    /// <summary>
    ///     Then step: Asserts that the extracted value length is less than the specified number of characters.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="length">The threshold length (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is less than '(.*)' characters long")]
    public void StringVariableIsLessThanLength(string jsonPath, string variableName, int length)
    {
        jsonPathDriver.StringVariableIsLessThanLength(jsonPath, variableName, length);
    }
}