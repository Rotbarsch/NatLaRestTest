using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that manages scenario variables lifecycle and access.
/// </summary>
public class VariableService : IVariableService
{
    private const string TestVariablesName = "reqnroll.json";

    private readonly Dictionary<string, string?> _variableStorage = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="VariableService" /> class and loads default variables from
    ///     <see cref="TestVariablesName" />.
    /// </summary>
    public VariableService()
    {
        LoadVariablesFromFile(TestVariablesName);
    }

    /// <inheritdoc />
    public string? GetVariable(string variableName)
    {
        if (!_variableStorage.ContainsKey(variableName))
        {
            Assert.Fail($"No variable named '{variableName}' found.");
        }

        return _variableStorage[variableName];
    }

    /// <inheritdoc />
    public void SetVariable(string variableName, string? variableValue)
    {
        if (_variableStorage.ContainsKey(variableName))
        {
            _variableStorage[variableName] = variableValue;
            return;
        }

        _variableStorage.Add(variableName, variableValue);
    }

    /// <inheritdoc />
    public void LoadVariablesFromFile(string filePath, bool failIfNotExist = false)
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
                    SetVariable(name, value);
                }
            }
        }
    }
}