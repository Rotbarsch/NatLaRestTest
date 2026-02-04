using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that manages scenario variables lifecycle and access.
/// </summary>
public class VariableService : IVariableService
{
    private readonly INatLaRestTestSettingsService _settingsService;
    private readonly Dictionary<string, string?> _variableStorage = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="VariableService" /> class.
    /// </summary>
    public VariableService(INatLaRestTestSettingsService settingsService)
    {
        _settingsService = settingsService;
        SetGlobalVariables();
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

    public string? ResolvePlaceHolderString(string? stringWithPlaceholders)
    {
        if (string.IsNullOrEmpty(stringWithPlaceholders)) return stringWithPlaceholders;

        // Match innermost placeholders only (no nested '(' or ')') in the variable name
        var pattern = "\\$\\(([^\\(\\)]+)\\)";
        var updated = stringWithPlaceholders;
        var safetyCounter = 0;

        // Resolve recursively until no more placeholders are found or safety limit reached
        while (Regex.IsMatch(updated, pattern) && safetyCounter < 100)
        {
            updated = Regex.Replace(updated, pattern, match =>
            {
                var variableName = match.Groups[1].Value;
                var value = GetVariable(variableName);
                return value ?? string.Empty;
            });

            safetyCounter++;
        }

        return updated;
    }

    public void LoadVariablesFromJson(string? json)
    {
        var jToken = JToken.Parse(json ?? string.Empty);

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

    private void SetGlobalVariables()
    {
        foreach (var v in _settingsService.GetVariables())
        {
            SetVariable(v.Name, v.Value);
        }
    }
}