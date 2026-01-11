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
}