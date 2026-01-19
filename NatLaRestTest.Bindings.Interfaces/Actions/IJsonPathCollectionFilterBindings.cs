namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings to filter JSON collections by evaluating JSONPath expressions against elements and applying comparison operations.
/// </summary>
public interface IJsonPathCollectionFilterBindings
{
    /// <summary>
    /// Filters the collection in the source variable by selecting elements where the JSONPath value is greater than the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.price' greater than '10' and stored in variable 'filteredItems'
    /// </summary>
    /// <param name="sourceVariableName">The name of the variable containing the JSON collection.</param>
    /// <param name="jPath">The JSONPath expression evaluated against each element.</param>
    /// <param name="comparisonValue">The value to compare against (as string).</param>
    /// <param name="targetVariableName">The variable to store the filtered collection into.</param>
    void FilterCollectionByJPathGreaterThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is greater than or equal to the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.qty' greater than or equal to '5' and stored in variable 'filteredItems'
    /// </summary>
    void FilterCollectionByJPathGreaterThanOrEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value equals the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.category' equal to 'Books' and stored in variable 'books'
    /// </summary>
    void FilterCollectionByJPathEquals(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value does not equal the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.status' not equal to 'Archived' and stored in variable 'activeItems'
    /// </summary>
    void FilterCollectionByJPathDoesNotEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is less than the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.discount' less than '0.2' and stored in variable 'smallDiscounts'
    /// </summary>
    void FilterCollectionByJPathLessThan(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is less than or equal to the comparison value.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.age' less than or equal to '18' and stored in variable 'minors'
    /// </summary>
    void FilterCollectionByJPathLessThanOrEqual(string sourceVariableName, string jPath, string comparisonValue, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is null.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.description' is null and stored in variable 'missingDescriptions'
    /// </summary>
    void FilterCollectionByJPathIsNull(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is not null.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.description' is not null and stored in variable 'withDescriptions'
    /// </summary>
    void FilterCollectionByJPathIsNotNull(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is not empty.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.tags' is not empty and stored in variable 'taggedItems'
    /// </summary>
    void FilterCollectionByJPathIsNotEmpty(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is empty.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.tags' is empty and stored in variable 'untaggedItems'
    /// </summary>
    void FilterCollectionByJPathIsEmpty(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with elements.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.children' has elements and stored in variable 'parents'
    /// </summary>
    void FilterCollectionByJPathHasElements(string sourceVariableName, string jPath, string targetVariableName);

    /// <summary>
    /// Filters the collection where the JSONPath value is a collection with no elements.
    /// Example usage: When the collection in variable 'items' is filtered by JSONPath '$.children' has no elements and stored in variable 'childless'
    /// </summary>
    void FilterCollectionByJPathHasNoElements(string sourceVariableName, string jPath, string targetVariableName);
}