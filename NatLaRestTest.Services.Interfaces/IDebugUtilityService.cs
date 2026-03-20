namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Interface for debug utility services.
/// </summary>
public interface IDebugUtilityService
{
    /// <summary>
    /// Dumps all currently set variables with their values.
    /// </summary>
    public string DumpVariables();

    /// <summary>
    /// Dumps the value of the specific variable.
    /// </summary>
    /// <param name="key">Name of the variable to inspect.</param>
    public string? DumpVariable(string key);

    /// <summary>
    /// Adds or updates a variable with value.
    /// </summary>
    /// <param name="key">Name of the variable to set or update.</param>
    /// <param name="value">Value to assign to the variable.</param>
    public string? SetVariable(string key, object? value);
}