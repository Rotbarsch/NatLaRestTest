using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a
///     JSON variable.
/// </summary>
[Binding]
public class BasicVariableJsonPathAssertions : IBasicVariableJsonPathAssertions
{
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    ///     Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a
    ///     JSON variable.
    /// </summary>
    public BasicVariableJsonPathAssertions(IJsonPathDriver jsonPathDriver)
    {
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable equals the given
    ///     comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The expected string value to compare against the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' equals:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' equals '(.*)'")]
    public void AssertValueEquals(string jsonPath, string variable, string comparison)
    {
        _jsonPathDriver.AssertValueEquals(jsonPath, variable, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the value selected by the provided JSONPath from the specified variable does not equal the
    ///     given comparison string.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    /// <param name="comparison">The string value that must not match the selected value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not equal:")]
    [Then("the value of JSONPath '(.*)' in variable '(.*)' does not equal '(.*)'")]
    public void AssertValueNotEquals(string jsonPath, string variable, string comparison)
    {
        _jsonPathDriver.AssertValueNotEquals(jsonPath, variable, comparison);
    }

    /// <summary>
    ///     Then step: Asserts that the provided JSONPath in the specified variable returns any value.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression used to select a value.</param>
    /// <param name="variable">The name of the variable containing a JSON string to evaluate.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' returns any value")]
    public void AssertJsonPathReturnsAnyValue(string jsonPath, string variable)
    {
        _jsonPathDriver.AssertJsonPathReturnsAnyValue(jsonPath, variable);
    }
}