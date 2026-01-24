using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings to load the content of a file and store it into a scenario variable.
/// </summary>
[Binding]
public class SetFromFileBindings(IFileSystemDriver fileSystemDriver) : ISetFromFileBindings
{
    /// <summary>
    ///     When step: Reads all text from the specified file path and stores it into the given variable.
    /// </summary>
    /// <param name="filePath">The path to the file to read.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the content of file '(.*)' is stored in variable '(.*)'")]
    public void SetVariableFromFile(string filePath, string variableName)
    {
        fileSystemDriver.SetVariableFromFile(filePath, variableName);
    }

    /// <summary>
    ///     Given step: Loads variables from a JSON file into the variable storage.
    /// </summary>
    /// <param name="filePath">Path to the variables JSON file.</param>
    [Given("the variables file '(.*)' is loaded")]
    public void LoadVariablesFile(string filePath)
    {
        fileSystemDriver.LoadVariablesFile(filePath);
    }
}