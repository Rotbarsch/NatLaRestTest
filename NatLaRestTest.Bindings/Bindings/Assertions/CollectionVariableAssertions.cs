using NatLaRestTest.Bindings.Drivers.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing assertions for variables representing JSON arrays (element count checks).
/// </summary>
[Binding]
public class CollectionVariableAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Step bindings providing assertions for variables representing JSON arrays (element count checks).
    /// </summary>
    public CollectionVariableAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the JSON array stored in the specified variable has at least one element.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    [Then("the value of variable '(.*)' has any elements")]
    public void AssertCollectionIsNotEmpty(string variableName)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count > 0, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array stored in the specified variable has no elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    [Then("the value of variable '(.*)' has no elements")]
    public void AssertCollectionIsEmpty(string variableName)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count == 0, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array stored in the specified variable has more than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    [Then("the value of variable '(.*)' has more than '(.*)' elements")]
    public void AssertCollectionHasMoreThanNElements(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count > count, $"Expected variable '{variableName}' to have more than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array stored in the specified variable has less than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    [Then("the value of variable '(.*)' has less than '(.*)' elements")]
    public void AssertCollectionHasLessThanNElements(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count < count, $"Expected variable '{variableName}' to have less than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Then step: Asserts that the JSON array stored in the specified variable has exactly the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The expected number of elements.</param>
    [Then("the value of variable '(.*)' has '(.*)' elements")]
    public void AssertCollectionHasExactCount(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.AreEqual(count,jArray.Count);
    }

    private JArray GetVariableAsArray(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName);
        var jArray = JArray.Parse(value!);
        return jArray;
    }
}