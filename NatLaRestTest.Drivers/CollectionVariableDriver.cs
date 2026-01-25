using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides assertions for collection values (JSON arrays) stored in scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionVariableDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
public class CollectionVariableDriver(IVariableService variableService) : ICollectionVariableDriver
{
    /// <summary>
    /// Asserts that the JSON array stored in the variable has at least one element.
    /// </summary>
    public void AssertCollectionIsNotEmpty(string variableName)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count > 0, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Asserts that the JSON array stored in the variable has no elements.
    /// </summary>
    public void AssertCollectionIsEmpty(string variableName)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count == 0, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Asserts that the JSON array stored in the variable has more than the provided element count.
    /// </summary>
    public void AssertCollectionHasMoreThanNElements(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count > count,
            $"Expected variable '{variableName}' to have more than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Asserts that the JSON array stored in the variable has less than the provided element count.
    /// </summary>
    public void AssertCollectionHasLessThanNElements(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.IsTrue(jArray.Count < count,
            $"Expected variable '{variableName}' to have less than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Asserts that the JSON array stored in the variable has the exact provided element count.
    /// </summary>
    public void AssertCollectionHasExactCount(string variableName, int count)
    {
        var jArray = GetVariableAsArray(variableName);
        Assert.AreEqual(count, jArray.Count);
    }

    private JArray GetVariableAsArray(string variableName)
    {
        var value = variableService.GetVariable(variableName);
        var jArray = JArray.Parse(value!);
        return jArray;
    }
}