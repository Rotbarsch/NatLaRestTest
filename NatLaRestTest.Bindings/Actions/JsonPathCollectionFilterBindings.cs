using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings to filter JSON collections by evaluating JSONPath expressions against elements and applying comparison operations.
/// </summary>
[Binding]
public class JsonPathCollectionFilterBindings(IJsonPathLogic jsonPathLogic) : IJsonPathCollectionFilterBindings
{
    /// <summary>
    /// Filters the collection in the source variable by selecting elements where the JSONPath value is greater than the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.price' greater than '10' and stored in variable 'filteredItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is greater than '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathGreaterThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.GreaterThan, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value is greater than or equal to the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.qty' greater than or equal to '5' and stored in variable 'filteredItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is greater than or equal '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathGreaterThanOrEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.GreaterThanOrEqual, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value equals the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.category' equal to 'Books' and stored in variable 'books'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' equals '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathEquals(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.Equals, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value does not equal the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.status' not equal to 'Archived' and stored in variable 'activeItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' does not equal '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathDoesNotEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.DoesNotEqual, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value is less than the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.discount' less than '0.2' and stored in variable 'smallDiscounts'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is less than '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathLessThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.LessThan, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value is less than or equal to the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.age' less than or equal to '18' and stored in variable 'minors'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is less than or equal '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathLessThanOrEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.LessThanOrEqual, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value is null.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.description' is null and stored in variable 'missingDescriptions'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is null is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNull(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNull);

    /// <summary>
    /// Filters the collection where the JSONPath value is not null.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.description' is not null and stored in variable 'withDescriptions'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is not null is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNotNull(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNotNull);

    /// <summary>
    /// Filters the collection where the JSONPath value is not empty.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.tags' is not empty and stored in variable 'taggedItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is not empty is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNotEmpty(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNotEmpty);

    /// <summary>
    /// Filters the collection where the JSONPath value is empty.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.tags' is empty and stored in variable 'untaggedItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is empty is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsEmpty(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsEmpty);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with elements.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.children' has elements and stored in variable 'parents'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' has elements is stored in variable '(.*)'")]
    public void FilterCollectionByJPathHasElements(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.HasElements);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with no elements.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.children' has no elements and stored in variable 'childless'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' has no elements is stored in variable '(.*)'")]
    public void FilterCollectionByJPathHasNoElements(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathLogic.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.HasNoElements);
}