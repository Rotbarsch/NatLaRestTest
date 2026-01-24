using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class NumericVariableJsonPathAssertions : INumericVariableJsonPathAssertions
{
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    ///     Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
    /// </summary>
    public NumericVariableJsonPathAssertions(IJsonPathDriver jsonPathDriver)
    {
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is greater than the
    ///     given value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is greater than '(.*)'")]
    public void NumericVariableIsGreaterThan(string jsonPath, string variableName, int value)
    {
        _jsonPathDriver.NumericVariableIsGreaterThan(jsonPath, variableName, value);
    }

    /// <summary>
    ///     Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is less than the given
    ///     value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    /// <param name="value">The threshold value (exclusive).</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' is less than '(.*)'")]
    public void NumericVariableIsLessThan(string jsonPath, string variableName, int value)
    {
        _jsonPathDriver.NumericVariableIsLessThan(jsonPath, variableName, value);
    }
}