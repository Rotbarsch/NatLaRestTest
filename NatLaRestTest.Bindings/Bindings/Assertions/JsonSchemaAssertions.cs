using NatLaRestTest.Bindings.Drivers.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing JSON Schema validation assertions for JSON stored in scenario variables.
/// </summary>
[Binding]
public class JsonSchemaAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonSchemaAssertions"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver dependency.</param>
    public JsonSchemaAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the JSON stored in the specified variable conforms to the provided JSON Schema.
    /// </summary>
    /// <param name="variableName">The variable containing the JSON document to validate.</param>
    /// <param name="jsonSchema">The JSON Schema to validate against.</param>
    [Then("the value of variable '(.*)' matches the JSON schema:")]
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