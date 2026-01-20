namespace NatLaRestTest.Bindings.Assertions.JsonPath;

/// <summary>
/// Step bindings providing boolean assertions on values resolved by JSONPath from JSON variables.
/// </summary>
public interface IBoolVariableJsonPathAssertions
{
    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable is true.
    /// Example usage: Then the value of JSONPath '$.active' in variable 'responseBody' is true
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    void AssertJsonPathReturnsTrue(string jsonPath, string variableName);

    /// <summary>
    /// Then step: Asserts that the value extracted by JSONPath from the specified variable is false.
    /// Example usage: Then the value of JSONPath '$.feature.enabled' in variable 'responseBody' is false
    /// </summary>
    /// <param name="jsonPath">The JSONPath expression.</param>
    /// <param name="variableName">The variable name containing JSON.</param>
    void AssertJsonPathReturnsFalse(string jsonPath, string variableName);
}