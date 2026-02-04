namespace NatLaRestTest.Services.Interfaces;

/// <summary>
///     Provides access to scenario variables for storing and retrieving values across steps.
/// </summary>
public interface IVariableService
{
    /// <summary>
    ///     Gets the value of a variable by name.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The variable value as string, or null if the stored value is null.</returns>
    string? GetVariable(string variableName);

    /// <summary>
    ///     Sets the value of a variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    void SetVariable(string variableName, string? variableValue);
    
    /// <summary>
    /// Replaces all variables in a given string (denoted by $() syntax with their actual value.
    /// </summary>
    /// <param name="stringWithPlaceholders">A string containing 0 or more placeholders.</param>
    /// <returns>String with resolved placeholders.</returns>
    string? ResolvePlaceHolderString(string stringWithPlaceholders);

    /// <summary>
    /// Extracts relevant variables from the supplied json.
    /// </summary>
    /// <param name="json">JSON to parse.</param>
    void LoadVariablesFromJson(string? json);
}