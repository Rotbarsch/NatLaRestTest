using System.Text;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

/// <summary>
/// Debug utiltiy service.
/// </summary>
public class DebugUtilityService(IVariableService variableService) : IDebugUtilityService
{
    /// <inheritdoc />
    public string DumpVariables()
    {
        var sb = new StringBuilder();
        foreach (var v in variableService.GetVariableNames())
        {
            var val = variableService.GetVariable(v);
            sb.AppendLine($"{v}={val}");
        }

        return sb.ToString();
    }

    /// <inheritdoc />
    public string? DumpVariable(string key)
    {
        if (variableService.GetVariableNames().Contains(key))
        {
            return variableService.GetVariable(key);
        }

        return "Variable not found.";
    }

    /// <inheritdoc />
    public string? SetVariable(string key, object? value)
    {
        variableService.SetVariable(key,value?.ToString());
        return DumpVariable(key);
    }
}