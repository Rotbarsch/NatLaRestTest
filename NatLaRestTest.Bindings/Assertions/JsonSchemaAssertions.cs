using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing JSON Schema validation assertions for JSON stored in scenario variables.
/// </summary>
[Binding]
public class JsonSchemaAssertions(IJsonSchemaLogic jsonSchemaLogic) : IJsonSchemaAssertions
{
    /// <summary>
    ///     Then step: Asserts that the JSON stored in the specified variable conforms to the provided JSON Schema.
    /// </summary>
    /// <param name="variableName">The variable containing the JSON document to validate.</param>
    /// <param name="jsonSchema">The JSON Schema to validate against.</param>
    [Then("the value of variable '(.*)' matches the JSON schema:")]
    public void AssertVariableConformsToJsonSchema(string variableName, string jsonSchema)
    {
        jsonSchemaLogic.AssertVariableConformsToJsonSchema(variableName, jsonSchema);
    }
}