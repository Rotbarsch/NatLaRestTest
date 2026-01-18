namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface ICollectionVariableAssertions
{
    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has at least one element.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    void AssertCollectionIsNotEmpty(string variableName);

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has no elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    void AssertCollectionIsEmpty(string variableName);

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has more than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    void AssertCollectionHasMoreThanNElements(string variableName, int count);

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has less than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    void AssertCollectionHasLessThanNElements(string variableName, int count);

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has exactly the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The expected number of elements.</param>
    void AssertCollectionHasExactCount(string variableName, int count);
}