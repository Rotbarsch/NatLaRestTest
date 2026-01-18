namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides file system operations for loading content into variables and reading variables files.
/// </summary>
public interface IFileSystemLogic
{
    /// <summary>
    /// Reads file contents and stores them in a variable.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    /// <param name="variableName">Target variable to store file contents.</param>
    void SetVariableFromFile(string filePath, string variableName);

    /// <summary>
    /// Loads variables from a JSON file in the expected format.
    /// </summary>
    /// <param name="filePath">Path to the variables file.</param>
    void LoadVariablesFile(string filePath);
}