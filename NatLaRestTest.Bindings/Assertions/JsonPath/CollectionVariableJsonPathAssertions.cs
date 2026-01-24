using NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
///     Step bindings providing assertions for JSON arrays resolved via JSONPath from JSON variables (element count
///     checks).
/// </summary>
[Binding]
public class CollectionVariableJsonPathAssertions : ICollectionVariableJsonPathAssertions
{
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    ///     Step bindings providing assertions for JSON arrays resolved via JSONPath from JSON variables (element count
    ///     checks).
    /// </summary>
    public CollectionVariableJsonPathAssertions(IJsonPathDriver jsonPathDriver)
    {
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with at least one
    ///     element.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has any elements")]
    public void AssertCollectionIsNotEmpty(string jsonPath, string variableName)
    {
        _jsonPathDriver.AssertCollectionIsNotEmpty(jsonPath, variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with no elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has no elements")]
    public void AssertCollectionIsEmpty(string jsonPath, string variableName)
    {
        _jsonPathDriver.AssertCollectionIsEmpty(jsonPath, variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has more than the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive lower bound for the number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has more than '(.*)' elements")]
    public void AssertCollectionHasMoreThanNElements(string jsonPath, string variableName, int count)
    {
        _jsonPathDriver.AssertCollectionHasMoreThanNElements(jsonPath, variableName, count);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has less than the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive upper bound for the number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has less than '(.*)' elements")]
    public void AssertCollectionHasLessThanNElements(string jsonPath, string variableName, int count)
    {
        _jsonPathDriver.AssertCollectionHasLessThanNElements(jsonPath, variableName, count);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has exactly the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The expected number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has '(.*)' elements")]
    public void AssertCollectionHasExactCount(string jsonPath, string variableName, int count)
    {
        _jsonPathDriver.AssertCollectionHasExactCount(jsonPath, variableName, count);
    }
}