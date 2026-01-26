namespace NatLaRestTest.Bindings.Interfaces.Assertions;

/// <summary>
/// Defines methods for reading variable values from files and loading variables from a JSON file into variable storage.
/// </summary>
public interface ISetFromFileBindings
{
    /// <summary>
    ///     When step: Reads all text from the specified file path and stores it into the given variable.
    /// </summary>
    /// <param name="filePath">The path to the file to read.</param>
    /// <param name="variableName">The target variable name.</param>
    void SetVariableFromFile(string filePath, string variableName);

    /// <summary>
    ///     Given step: Loads variables from a JSON file into the variable storage.
    /// </summary>
    /// <param name="filePath">Path to the variables JSON file.</param>
    void LoadVariablesFile(string filePath);
}