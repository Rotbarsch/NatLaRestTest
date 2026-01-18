namespace NatLaRestTest.Bindings.Interfaces.Assertions.JsonPath;

public interface ICollectionVariableJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with at least one
    ///     element.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    void AssertCollectionIsNotEmpty(string jsonPath, string variableName);

    /// <summary>
    ///     Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with no elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    void AssertCollectionIsEmpty(string jsonPath, string variableName);

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has more than the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive lower bound for the number of elements.</param>
    void AssertCollectionHasMoreThanNElements(string jsonPath, string variableName, int count);

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has less than the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The exclusive upper bound for the number of elements.</param>
    void AssertCollectionHasLessThanNElements(string jsonPath, string variableName, int count);

    /// <summary>
    ///     Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has exactly the
    ///     provided number of elements.
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression selecting the array.</param>
    /// <param name="variableName">The variable name containing a JSON value.</param>
    /// <param name="count">The expected number of elements.</param>
    void AssertCollectionHasExactCount(string jsonPath, string variableName, int count);
}