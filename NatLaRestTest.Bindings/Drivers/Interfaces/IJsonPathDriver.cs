namespace NatLaRestTest.Bindings.Drivers.Interfaces;

/// <summary>
/// Resolves values from JSON content using JSONPath expressions.
/// </summary>
public interface IJsonPathDriver
{
    /// <summary>
    /// Gets a value from JSON using a JSONPath expression.
    /// </summary>
    /// <param name="inputJson">The input JSON string.</param>
    /// <param name="jsonPathExpression">The JSONPath expression to evaluate.</param>
    /// <returns>The resolved value as string, or null if not found.</returns>
    string? GetValueFromJsonPath(string? inputJson, string jsonPathExpression);

    /// <summary>
    /// Returns whether or not the provided JSONPath expression resolves to any value in the input JSON, in short checking if a given property exists.
    /// </summary>
    /// <param name="inputJson">The input JSON string.</param>
    /// <param name="jsonPathExpression">The JSONPath expression to evaluate.</param>
    /// <returns><code>true</code> if JSONPath expressions resolves on input; else <code>false</code>.</returns>
    bool JsonPathReturnsAnyValue(string? inputJson, string jsonPathExpression);
}