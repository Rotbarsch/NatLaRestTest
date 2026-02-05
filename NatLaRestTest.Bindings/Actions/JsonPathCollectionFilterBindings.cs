using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings to filter JSON collections by evaluating JSONPath expressions against elements and applying comparison operations.
/// </summary>
[Binding]
public class JsonPathCollectionFilterBindings(IJsonPathDriver jsonPathDriver) : IJsonPathCollectionFilterBindings
{
    /// <summary>
    /// Filters the collection in the source variable by selecting elements where the JSONPath value is greater than the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is greater than '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathGreaterThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.GreaterThan, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value equals the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' equals '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathEquals(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.Equals, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value does not equal the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' does not equal '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathDoesNotEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.DoesNotEqual, comparisonValue);


    /// <summary>
    /// Filters the collection where the JSONPath value is boolean true.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is true is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsTrue(string sourceVariableName, string jPath, string targetVariableName)
    {
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName,jPath,targetVariableName,ComparisonOperation.BoolEquals, true.ToString());
    }

    /// <summary>
    /// Filters the collection where the JSONPath value is boolean false.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is false is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsFalse(string sourceVariableName, string jPath, string targetVariableName)
    {
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.BoolEquals, false.ToString());
    }

    /// <summary>
    /// Filters the collection where the JSONPath value is less than the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is less than '(.*)' is stored in variable '(.*)'")]
    public void FilterCollectionByJPathLessThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.LessThan, comparisonValue);

    /// <summary>
    /// Filters the collection where the JSONPath value is null.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is null is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNull(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNull);

    /// <summary>
    /// Filters the collection where the JSONPath value is not null.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is not null is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNotNull(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNotNull);

    /// <summary>
    /// Filters the collection where the JSONPath value is not empty.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is not empty is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsNotEmpty(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsNotEmpty);

    /// <summary>
    /// Filters the collection where the JSONPath value is empty.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is empty is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsEmpty(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.IsEmpty);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with elements.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' has elements is stored in variable '(.*)'")]
    public void FilterCollectionByJPathHasElements(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.HasElements);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with no elements.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' has no elements is stored in variable '(.*)'")]
    public void FilterCollectionByJPathHasNoElements(string sourceVariableName, string jPath, string targetVariableName) =>
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.HasNoElements);

    /// <summary>
    /// Filters the collection where the JSONPath value is valid (property does exist).
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is valid is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsValid(string sourceVariableName, string jPath, string targetVariableName)
    {
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName,jPath,targetVariableName,ComparisonOperation.JsonPathValid);
    }

    /// <summary>
    /// Filters the collection where the JSONPath value is invalid (property does not exist).
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    [When("each element of collection in variable '(.*)' where the value of JSONPath '(.*)' is not valid is stored in variable '(.*)'")]
    public void FilterCollectionByJPathIsInvalid(string sourceVariableName, string jPath, string targetVariableName)
    {
        jsonPathDriver.FilterCollectionByJPath(sourceVariableName, jPath, targetVariableName, ComparisonOperation.JsonPathInvalid);
    }
}