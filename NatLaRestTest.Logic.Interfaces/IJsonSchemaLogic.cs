namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides operations to validate variables against JSON Schema definitions.
/// </summary>
public interface IJsonSchemaLogic
{
    /// <summary>
    /// Asserts that the specified variable's JSON content conforms to the provided JSON schema.
    /// </summary>
    /// <param name="variableName">Name of the variable containing JSON content.</param>
    /// <param name="jsonSchema">JSON Schema definition as string.</param>
    void AssertVariableConformsToJsonSchema(string variableName, string jsonSchema);
}