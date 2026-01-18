using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
/// </summary>
[Binding]
public class NumericVariableJsonPathAssertions : INumericVariableJsonPathAssertions
{
    private readonly IJsonPathLogic _jsonPathLogic;

    /// <summary>
    ///     Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.
    /// </summary>
    public NumericVariableJsonPathAssertions(IJsonPathLogic jsonPathLogic)
    {
        _jsonPathLogic = jsonPathLogic;
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
        _jsonPathLogic.NumericVariableIsGreaterThan(jsonPath, variableName, value);
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
        _jsonPathLogic.NumericVariableIsLessThan(jsonPath, variableName, value);
    }
}