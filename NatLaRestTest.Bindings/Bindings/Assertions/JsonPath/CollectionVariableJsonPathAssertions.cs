using NatLaRestTest.Bindings.Drivers.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing assertions for JSON arrays resolved via JSONPath from JSON variables (element count checks).
/// </summary>
[Binding]
public class CollectionVariableJsonPathAssertions
{
    private readonly IVariableDriver _variableDriver;
    private readonly IJsonPathDriver _jsonPathDriver;

    /// <summary>
    /// Step bindings providing assertions for JSON arrays resolved via JSONPath from JSON variables (element count checks).
    /// </summary>
    public CollectionVariableJsonPathAssertions(IVariableDriver variableDriver, IJsonPathDriver jsonPathDriver)
    {
        _variableDriver = variableDriver;
        _jsonPathDriver = jsonPathDriver;
    }

    /// <summary>
    /// Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with at least one element.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has any elements")]
    public void AssertCollectionIsNotEmpty(string jsonPath, string variableName)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count > 0, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with no elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has no elements")]
    public void AssertCollectionIsEmpty(string jsonPath, string variableName)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count == 0, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has more than the provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive lower bound for the number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has more than '(.*)' elements")]
    public void AssertCollectionHasMoreThanNElements(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count > count, $"Expected variable '{variableName}' to have more than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has less than the provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive upper bound for the number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has less than '(.*)' elements")]
    public void AssertCollectionHasLessThanNElements(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count < count, $"Expected variable '{variableName}' to have less than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has exactly the provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The expected number of elements.</param>
    [Then("the value of JSONPath '(.*)' in variable '(.*)' has '(.*)' elements")]
    public void AssertCollectionHasExactCount(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.AreEqual(count, jArray.Count);
    }

    private JArray GetSelectionArray(string variableName, string jsonPath)
    {
        var selection = _jsonPathDriver.GetValueFromJsonPath(_variableDriver.GetVariable(variableName), jsonPath);
        Assert.IsNotNull(selection, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");
        return JArray.Parse(selection!.ToString());
    }
}