using NatLaRestTest.Bindings.Drivers.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Bindings.Drivers;

/// <summary>
/// Driver that manages scenario variables lifecycle and access.
/// </summary>
public class VariableDriver : IVariableDriver
{
    private const string TestVariablesName = "reqnroll.json";

    private readonly Dictionary<string, string?> _variableStorage = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="VariableDriver"/> class and loads default variables from <see cref="TestVariablesName"/>.
    /// </summary>
    public VariableDriver()
    {
        LoadVariablesFromFile(TestVariablesName);
    }

    /// <summary>
    /// Gets the value of a stored variable by name.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The stored value, or null if the value is null.</returns>
    public string? GetVariable(string variableName)
    {
        Assert.IsTrue(_variableStorage.ContainsKey(variableName), $"No variable named '{variableName}' found.");
        return _variableStorage[variableName];
    }

    /// <summary>
    /// Sets or adds a variable with the given value.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    public void SetVariable(string variableName, string? variableValue)
    {
        if (_variableStorage.ContainsKey(variableName))
        {
            _variableStorage[variableName] = variableValue;
            return;
        }
        _variableStorage.Add(variableName, variableValue);
    }

    /// <summary>
    /// Loads variables from a JSON file in the expected format, optionally failing if the file does not exist.
    /// </summary>
    /// <param name="filePath">Path to the JSON file.</param>
    /// <param name="failIfNotExist">If true, asserts failure when the file does not exist.</param>
    public void LoadVariablesFromFile(string filePath, bool failIfNotExist=false)
    {
        var fileExists = File.Exists(filePath);
        if (!fileExists && failIfNotExist)
        {
            Assert.Fail($"File '{filePath}' does not exist.");
        }

        if (fileExists)
        {
            var json = File.ReadAllText(filePath);
            var jToken = JToken.Parse(json);

            if (jToken["testVariables"] is null) return;

            foreach (var entry in jToken["testVariables"]!)
            {
                var name = entry.SelectToken("$.name")?.Value<string>();
                var value = entry.SelectToken("$.value")?.Value<string?>();

                if (name is not null)
                {
                    SetVariable(name,value);
                }
            }
        }
    }
}