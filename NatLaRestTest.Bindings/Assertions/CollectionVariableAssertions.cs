using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing assertions for variables representing JSON arrays (element count checks).
/// </summary>
[Binding]
public class CollectionVariableAssertions : ICollectionVariableAssertions
{
    private readonly ICollectionVariableLogic _collectionVariableLogic;

    /// <summary>
    ///     Step bindings providing assertions for variables representing JSON arrays (element count checks).
    /// </summary>
    public CollectionVariableAssertions(ICollectionVariableLogic collectionVariableLogic)
    {
        _collectionVariableLogic = collectionVariableLogic;
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has at least one element.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    [Then("the value of variable '(.*)' has any elements")]
    public void AssertCollectionIsNotEmpty(string variableName)
    {
        _collectionVariableLogic.AssertCollectionIsNotEmpty(variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has no elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    [Then("the value of variable '(.*)' has no elements")]
    public void AssertCollectionIsEmpty(string variableName)
    {
        _collectionVariableLogic.AssertCollectionIsEmpty(variableName);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has more than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    [Then("the value of variable '(.*)' has more than '(.*)' elements")]
    public void AssertCollectionHasMoreThanNElements(string variableName, int count)
    {
        _collectionVariableLogic.AssertCollectionHasMoreThanNElements(variableName, count);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has less than the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The threshold (exclusive) for element count.</param>
    [Then("the value of variable '(.*)' has less than '(.*)' elements")]
    public void AssertCollectionHasLessThanNElements(string variableName, int count)
    {
        _collectionVariableLogic.AssertCollectionHasLessThanNElements(variableName, count);
    }

    /// <summary>
    ///     Then step: Asserts that the JSON array stored in the specified variable has exactly the given number of elements.
    /// </summary>
    /// <param name="variableName">The variable name containing a JSON array string.</param>
    /// <param name="count">The expected number of elements.</param>
    [Then("the value of variable '(.*)' has '(.*)' elements")]
    public void AssertCollectionHasExactCount(string variableName, int count)
    {
        _collectionVariableLogic.AssertCollectionHasExactCount(variableName, count);
    }
}