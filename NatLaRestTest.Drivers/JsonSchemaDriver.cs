using System;
using System.Collections.Generic;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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

        var schema = JSchema.Parse(jsonSchema);
        var jsonObject = JObject.Parse(value!);
        if (!jsonObject.IsValid(schema, out IList<string> errorMessages))
        {
            var errors = string.Join("; ", errorMessages);
            Assert.Fail($"Variable '{variableName}' does not conform to the JSON schema. Errors: {errors}");
        }
    }
}