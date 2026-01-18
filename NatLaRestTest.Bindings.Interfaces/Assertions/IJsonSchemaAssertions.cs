namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface IJsonSchemaAssertions
{
    /// <summary>
    ///     Then step: Asserts that the JSON stored in the specified variable conforms to the provided JSON Schema.
    /// </summary>
    /// <param name="variableName">The variable containing the JSON document to validate.</param>
    /// <param name="jsonSchema">The JSON Schema to validate against.</param>
    void AssertVariableConformsToJsonSchema(string variableName, string jsonSchema);
}