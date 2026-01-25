using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to read file contents and load variables from files into scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FileSystemDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to set and load scenario variables.</param>
public class FileSystemDriver(IVariableService variableService) : IFileSystemDriver
{

    /// <summary>
    /// Reads the text content from the provided file path and stores it in the specified scenario variable.
    /// </summary>
    /// <param name="filePath">Path to the source text file.</param>
    /// <param name="variableName">Name of the scenario variable to store the file content in.</param>
    public void SetVariableFromFile(string filePath, string variableName)
    {
        var content = File.ReadAllText(filePath);
        variableService.SetVariable(variableName, content);
    }

    /// <summary>
    /// Loads variables from the specified variables file using the underlying Service.
    /// </summary>
    /// <param name="filePath">Path to the variables file (e.g., JSON).</param>
    public void LoadVariablesFile(string filePath)
    {
        variableService.LoadVariablesFromFile(filePath);
    }
}