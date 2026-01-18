using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides logic to read file contents and load variables from files into scenario variables.
/// </summary>
public class FileSystemLogic : IFileSystemLogic
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileSystemLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to set and load scenario variables.</param>
    public FileSystemLogic(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Reads the text content from the provided file path and stores it in the specified scenario variable.
    /// </summary>
    /// <param name="filePath">Path to the source text file.</param>
    /// <param name="variableName">Name of the scenario variable to store the file content in.</param>
    public void SetVariableFromFile(string filePath, string variableName)
    {
        var content = File.ReadAllText(filePath);
        _variableDriver.SetVariable(variableName, content);
    }

    /// <summary>
    /// Loads variables from the specified variables file using the underlying driver.
    /// </summary>
    /// <param name="filePath">Path to the variables file (e.g., JSON).</param>
    public void LoadVariablesFile(string filePath)
    {
        _variableDriver.LoadVariablesFromFile(filePath);
    }
}