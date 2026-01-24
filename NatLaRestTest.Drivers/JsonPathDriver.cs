using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides operations to evaluate JSONPath expressions against JSON stored in scenario variables,
/// assert values and collection counts, and store selections into variables.
/// </summary>
public class JsonPathDriver : IJsonPathDriver
{
    private readonly IJsonPathService _jsonPathService;
    private readonly IVariableService _variableService;
    private readonly IComparisonService _comparisonService;
    private readonly IBoolService _boolService;
    private readonly INumericService _numericService;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonPathDriver"/> class.
    /// </summary>
    /// <param name="jsonPathService">Service used to evaluate JSONPath expressions.</param>
    /// <param name="variableService">Service used to access scenario variables.</param>
    public JsonPathDriver(IJsonPathService jsonPathService, IVariableService variableService, IComparisonService comparisonDriver, IBoolService boolService, INumericService numericService)
    {
        _jsonPathService = jsonPathService;
        _variableService = variableService;
        _comparisonService = comparisonDriver;
        _boolService = boolService;
        _numericService = numericService;
    }

    /// <summary>
    /// Evaluates a JSONPath expression against the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="jPath">JSONPath expression.</param>
    /// <param name="sourceVariableName">Variable containing the JSON source.</param>
    /// <param name="targetVariableName">Variable to store the evaluation result.</param>
    public void SetVariableFromJPath(string jPath, string sourceVariableName, string targetVariableName)
    {
        var selection = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(sourceVariableName), jPath);
        _variableService.SetVariable(targetVariableName, selection);
    }

    /// <summary>
    /// Asserts that the value at the given JSONPath equals the comparison value.
    /// </summary>
    public void AssertValueEquals(string jsonPath, string variable, string comparison)
    {
        var selection = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variable), jsonPath);
        Assert.AreEqual(comparison, selection,
            $"The value at JSONPath '{jsonPath}' in variable '{variable}' does not equal '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the value at the given JSONPath does not equal the comparison value.
    /// </summary>
    public void AssertValueNotEquals(string jsonPath, string variable, string comparison)
    {
        var selection = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variable), jsonPath);
        Assert.AreNotEqual(comparison, selection,
            $"The value at JSONPath '{jsonPath}' in variable '{variable}' equals '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the JSONPath resolves to any value.
    /// </summary>
    public void AssertJsonPathReturnsAnyValue(string jsonPath, string variable)
    {
        Assert.True(_jsonPathService.JsonPathReturnsAnyValue(_variableService.GetVariable(variable), jsonPath),
            $"JSONPath expression '{jsonPath}' did not resolve in variable '{variable}'.");
    }

    /// <summary>
    /// Asserts that the selected array has at least one element.
    /// </summary>
    public void AssertCollectionIsNotEmpty(string jsonPath, string variableName)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count > 0, $"Variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Asserts that the selected array has no elements.
    /// </summary>
    public void AssertCollectionIsEmpty(string jsonPath, string variableName)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count == 0, $"Variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Asserts that the selected array has more than the provided element count.
    /// </summary>
    public void AssertCollectionHasMoreThanNElements(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count > count,
            $"Expected variable '{variableName}' to have more than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Asserts that the selected array has less than the provided element count.
    /// </summary>
    public void AssertCollectionHasLessThanNElements(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.IsTrue(jArray.Count < count,
            $"Expected variable '{variableName}' to have less than {count} elements, but actually has {jArray.Count}");
    }

    /// <summary>
    /// Asserts that the selected array has the exact provided element count.
    /// </summary>
    public void AssertCollectionHasExactCount(string jsonPath, string variableName, int count)
    {
        var jArray = GetSelectionArray(variableName, jsonPath);
        Assert.AreEqual(count, jArray.Count);
    }

    /// <summary>
    /// Asserts that the numeric value selected by JSONPath is greater than the provided value.
    /// </summary>
    public void NumericVariableIsGreaterThan(string jsonPath, string variableName, int value)
    {
        var actualValue = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variableName), jsonPath);
        Assert.NotNull(actualValue, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");

        var str = actualValue!;
        Assert.IsTrue(_numericService.ParseNumber(actualValue,out var parsed),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not numeric. Actual: '{str}'.");

        Assert.Greater(parsed, value,
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not more than {value}.");
    }

    /// <summary>
    /// Asserts that the numeric value selected by JSONPath is less than the provided value.
    /// </summary>
    public void NumericVariableIsLessThan(string jsonPath, string variableName, int value)
    {
        var actualValue = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variableName), jsonPath);
        Assert.NotNull(actualValue, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");

        var str = actualValue!;
        Assert.IsTrue(_numericService.ParseNumber(actualValue,out var parsed),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not numeric. Actual: '{str}'.");

        Assert.Less(parsed, value,
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not less than {value}.");
    }

    /// <summary>
    /// Asserts that the selected string contains the provided comparison value.
    /// </summary>
    public void StringVariableContains(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.Contains(comparison),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' does not contain '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string does not contain the provided comparison value.
    /// </summary>
    public void StringVariableNotContains(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.Contains(comparison),
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' contains '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string starts with the provided comparison value.
    /// </summary>
    public void StringVariableStartsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.StartsWith(comparison),
            $"The value at JSONPath '{jsonPath} in variable '{variableName}' does not start with '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string does not start with the provided comparison value.
    /// </summary>
    public void StringVariableNotStartsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.StartsWith(comparison),
            $"The value at JSONPath '{jsonPath} in variable '{variableName}' starts with '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string ends with the provided comparison value.
    /// </summary>
    public void StringVariableEndsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsTrue(value.EndsWith(comparison),
            $"The value at JSONPath '{jsonPath} in variable '{variableName}' does not end with '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string does not end with the provided comparison value.
    /// </summary>
    public void StringVariableNotEndsWith(string jsonPath, string variableName, string comparison)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsFalse(value.EndsWith(comparison),
            $"The value at JSONPath '{jsonPath} in variable '{variableName}' ends with '{comparison}'.");
    }

    /// <summary>
    /// Asserts that the selected string has exactly the provided length.
    /// </summary>
    public void StringVariableIsLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.AreEqual(length, value.Length,
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not {length} characters long.");
    }

    /// <summary>
    /// Asserts that the selected string is not empty.
    /// </summary>
    public void StringVariableIsNotEmpty(string jsonPath, string variableName)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsNotEmpty(value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is empty.");
    }

    /// <summary>
    /// Asserts that the selected string is empty.
    /// </summary>
    public void StringVariableIsEmpty(string jsonPath, string variableName)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.IsEmpty(value, $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not empty.");
    }

    /// <summary>
    /// Asserts that the selected string is longer than the provided length.
    /// </summary>
    public void StringVariableIsMoreThanLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.Greater(value.Length, length,
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not more than {length} characters long.");
    }

    /// <summary>
    /// Asserts that the selected string is shorter than the provided length.
    /// </summary>
    public void StringVariableIsLessThanLength(string jsonPath, string variableName, int length)
    {
        var value = GetSelectionString(jsonPath, variableName);
        Assert.Less(value.Length, length,
            $"The value at JSONPath '{jsonPath}' in variable '{variableName}' is not less than {length} characters long.");
    }

    public void FilterCollectionByJPath(string sourceVariableName, string jPath, string targetVariableName,
        ComparisonOperation comparisonOperation, string? comparisonValue=null)
    {
        var selection = _variableService.GetVariable(sourceVariableName);
        Assert.NotNull(selection,$"Value of variable '{sourceVariableName}' is null and cannot be parsed as collection.");
        var jArray = JArray.Parse(selection!);
        var result = new JArray();

        foreach (var item in jArray)
        {
            var jsonPathOnItem = _jsonPathService.GetValueFromJsonPath(item.ToString(), jPath);

            var fitsCriteria = _comparisonService.Compare(jsonPathOnItem, comparisonOperation, comparisonValue);

            if (fitsCriteria)
            {
                result.Add(item);
            }
        }

        _variableService.SetVariable(targetVariableName,result.ToString());
    }

    public void AssertJsonPathReturnsBoolean(string variableName, string jsonPath, bool expected)
    {
        _boolService.AreBooleanEqual(expected, _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variableName), jsonPath));
    }

    private string GetSelectionString(string jsonPath, string variableName)
    {
        var value = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variableName), jsonPath);
        Assert.NotNull(value, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");
        return value!;
    }

    private JArray GetSelectionArray(string variableName, string jsonPath)
    {
        var selection = _jsonPathService.GetValueFromJsonPath(_variableService.GetVariable(variableName), jsonPath);
        Assert.IsNotNull(selection, $"JSONPath '{jsonPath}' on variable '{variableName}' returned null.");
        return JArray.Parse(selection!);
    }
}