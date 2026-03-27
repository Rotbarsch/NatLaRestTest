using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NJsonSchema;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to validate JSON content stored in variables against JSON Schema definitions.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JsonSchemaDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
public class JsonSchemaDriver(IVariableService variableService) : IJsonSchemaDriver
{

    /// <summary>
    /// Asserts that the specified variable's JSON content conforms to the provided JSON schema.
    /// </summary>
    /// <param name="variableName">Name of the variable containing JSON content.</param>
    /// <param name="jsonSchema">JSON Schema definition as string.</param>
    /// <exception cref="Exception">Thrown when the variable is null or does not conform to the schema.</exception>
    public void AssertVariableConformsToJsonSchema(string variableName, string jsonSchema)
    {
        var value = variableService.GetVariable(variableName);
        if (value is null)
        {
            Assert.Fail($"Variable '{variableName}' is null.");
        }

        var schema = JsonSchema.FromSampleJson(jsonSchema);
        var errors = schema.Validate(value!);
        if (errors.Count > 0)
        {
            var errorMessages = string.Join("; ", errors.Select(e => e.ToString()));
            Assert.Fail($"Variable '{variableName}' does not conform to the JSON schema. Errors: {errorMessages}");
        }
    }
}