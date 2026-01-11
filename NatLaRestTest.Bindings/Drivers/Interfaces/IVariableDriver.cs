namespace NatLaRestTest.Bindings.Drivers.Interfaces;

/// <summary>
/// Provides access to scenario variables for storing and retrieving values across steps.
/// </summary>
public interface IVariableDriver
{
    /// <summary>
    /// Gets the value of a variable by name.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The variable value as string, or null if the stored value is null.</returns>
    string? GetVariable(string variableName);

    /// <summary>
    /// Sets the value of a variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    void SetVariable(string variableName, string? variableValue);

    /// <summary>
    /// Loads variables from a JSON file in the expected format.
    /// </summary>
    /// <param name="filePath">Path to the JSON file.</param>
    /// <param name="failIfNotExist">If true, asserts failure when the file does not exist.</param>
    void LoadVariablesFromFile(string filePath, bool failIfNotExist=false);
}