namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings to filter JSON collections by evaluating JSONPath expressions against elements and applying comparison operations.
/// </summary>
public interface IJsonPathCollectionFilterBindings
{
    /// <summary>
    /// Filters the collection in the source variable by selecting elements where the JSONPath value is greater than the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathGreaterThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value equals the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathEquals(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value does not equal the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathDoesNotEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is boolean true.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsTrue(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is boolean false.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsFalse(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is less than the comparison value.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathLessThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is null.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsNull(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is not null.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsNotNull(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is not empty.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsNotEmpty(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is empty.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathIsEmpty(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with elements.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathHasElements(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with no elements.
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathHasNoElements(string sourceVariableName, string jPath, string targetVariableName);
}