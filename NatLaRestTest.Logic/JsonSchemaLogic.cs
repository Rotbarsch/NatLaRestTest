using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides logic to validate JSON content stored in variables against JSON Schema definitions.
/// </summary>
public class JsonSchemaLogic : IJsonSchemaLogic
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonSchemaLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to access scenario variables.</param>
    public JsonSchemaLogic(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Asserts that the specified variable's JSON content conforms to the provided JSON schema.
    /// </summary>
    /// <param name="variableName">Name of the variable containing JSON content.</param>
    /// <param name="jsonSchema">JSON Schema definition as string.</param>
    /// <exception cref="Exception">Thrown when the variable is null or does not conform to the schema.</exception>
    public void AssertVariableConformsToJsonSchema(string variableName, string jsonSchema)
    {
        var value = _variableDriver.GetVariable(variableName);
        if (value == null)
        {
            throw new Exception($"Variable '{variableName}' is null.");
        }

        var schema = JSchema.Parse(jsonSchema);
        var jsonObject = JObject.Parse(value);
        if (!jsonObject.IsValid(schema, out IList<string> errorMessages))
        {
            var errors = string.Join("; ", errorMessages);
            throw new Exception($"Variable '{variableName}' does not conform to the JSON schema. Errors: {errors}");
        }
    }
}