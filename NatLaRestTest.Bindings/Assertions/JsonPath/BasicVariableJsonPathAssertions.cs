using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a
///     JSON variable.
/// </summary>
[Binding]
public class BasicVariableJsonPathAssertions : IBasicVariableJsonPathAssertions
{
    private readonly IJsonPathLogic _jsonPathLogic;

    /// <summary>
    ///     Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a
    ///     JSON variable.
    /// </summary>
    public BasicVariableJsonPathAssertions(IJsonPathLogic jsonPathLogic)
    {
        _jsonPathLogic = jsonPathLogic;
    }

    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable equals the given
    ///     comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The expected string value to compare against the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' equals '(.*)'")]
    public void AssertValueEquals(string jsonPath, string variable, string comparison)
    {
        _jsonPathLogic.AssertValueEquals(jsonPath, variable, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable does not equal the
    ///     given comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The string value that must not match the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not equal '(.*)'")]
    public void AssertValueNotEquals(string jsonPath, string variable, string comparison)
    {
        _jsonPathLogic.AssertValueNotEquals(jsonPath, variable, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the provided JSONPath in the specified variable returns any value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' returns any value")]
    public void AssertJsonPathReturnsAnyValue(string jsonPath, string variable)
    {
        _jsonPathLogic.AssertJsonPathReturnsAnyValue(jsonPath, variable);
    }
}