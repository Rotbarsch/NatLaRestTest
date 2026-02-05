using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Provides JSONPath-based operations and assertions on values stored in variables.
/// </summary>
public interface IJsonPathDriver
{
    /// <summary>
    /// Evaluates a JSONPath against the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="jPath">JSONPath expression.</param>
    /// <param name="sourceVariableName">Variable containing the JSON source.</param>
    /// <param name="targetVariableName">Variable to store the evaluation result.</param>
    void SetVariableFromJPath(string jPath, string sourceVariableName, string targetVariableName);

    /// <summary>Asserts equality of the JSONPath result and the comparison value.</summary>
    void AssertValueEquals(string jsonPath, string variable, string comparison);

    /// <summary>Asserts inequality of the JSONPath result and the comparison value.</summary>
    void AssertValueNotEquals(string jsonPath, string variable, string comparison);

    /// <summary>Asserts that the JSONPath returns any non-null value.</summary>
    void AssertJsonPathReturnsAnyValue(string jsonPath, string variable);

    /// <summary>Asserts collection is not empty for the JSONPath result.</summary>
    void AssertCollectionIsNotEmpty(string jsonPath, string variableName);

    /// <summary>Asserts collection is empty for the JSONPath result.</summary>
    void AssertCollectionIsEmpty(string jsonPath, string variableName);

    /// <summary>Asserts collection has more than the specified number of elements.</summary>
    void AssertCollectionHasMoreThanNElements(string jsonPath, string variableName, int count);

    /// <summary>Asserts collection has fewer than the specified number of elements.</summary>
    void AssertCollectionHasLessThanNElements(string jsonPath, string variableName, int count);

    /// <summary>Asserts collection has exactly the specified number of elements.</summary>
    void AssertCollectionHasExactCount(string jsonPath, string variableName, int count);

    /// <summary>Asserts the numeric result is greater than the specified value.</summary>
    void NumericVariableIsGreaterThan(string jsonPath, string variableName, int value);

    /// <summary>Asserts the numeric result is less than the specified value.</summary>
    void NumericVariableIsLessThan(string jsonPath, string variableName, int value);

    /// <summary>Asserts the string result contains the comparison value.</summary>
    void StringVariableContains(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result does not contain the comparison value.</summary>
    void StringVariableNotContains(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result starts with the comparison value.</summary>
    void StringVariableStartsWith(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result does not start with the comparison value.</summary>
    void StringVariableNotStartsWith(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result ends with the comparison value.</summary>
    void StringVariableEndsWith(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result does not end with the comparison value.</summary>
    void StringVariableNotEndsWith(string jsonPath, string variableName, string comparison);

    /// <summary>Asserts the string result has the specified length.</summary>
    void StringVariableIsLength(string jsonPath, string variableName, int length);

    /// <summary>Asserts the string result is not empty.</summary>
    void StringVariableIsNotEmpty(string jsonPath, string variableName);

    /// <summary>Asserts the string result is empty.</summary>
    void StringVariableIsEmpty(string jsonPath, string variableName);

    /// <summary>Asserts the string result length is greater than the specified length.</summary>
    void StringVariableIsMoreThanLength(string jsonPath, string variableName, int length);

    /// <summary>Asserts the string result length is less than the specified length.</summary>
    void StringVariableIsLessThanLength(string jsonPath, string variableName, int length);

    void FilterCollectionByJPath(string sourceVariableName, string jPath, string targetVariableName, ComparisonOperation comparisonOperation, string? comparisonValue = null);
    
    void AssertJsonPathReturnsBoolean(string variableName, string jsonPath, bool expected);
    void AssertJsonPathDoesNotReturnAnyValue(string jPath, string sourceVariableName);
}