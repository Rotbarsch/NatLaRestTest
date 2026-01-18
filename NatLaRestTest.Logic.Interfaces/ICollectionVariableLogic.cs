namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides assertions on variables storing collections (e.g., arrays, lists).
/// </summary>
public interface ICollectionVariableLogic
{
    /// <summary>
    /// Asserts that the collection variable is not empty.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    void AssertCollectionIsNotEmpty(string variableName);

    /// <summary>
    /// Asserts that the collection variable is empty.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    void AssertCollectionIsEmpty(string variableName);

    /// <summary>
    /// Asserts that the collection variable contains more than the specified number of elements.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="count">The threshold count.</param>
    void AssertCollectionHasMoreThanNElements(string variableName, int count);

    /// <summary>
    /// Asserts that the collection variable contains fewer than the specified number of elements.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="count">The threshold count.</param>
    void AssertCollectionHasLessThanNElements(string variableName, int count);

    /// <summary>
    /// Asserts that the collection variable contains exactly the specified number of elements.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="count">The expected count.</param>
    void AssertCollectionHasExactCount(string variableName, int count);
}