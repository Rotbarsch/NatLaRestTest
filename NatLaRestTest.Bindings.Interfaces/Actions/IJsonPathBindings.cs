namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings for extracting values from JSON using JSONPath and storing them in scenario variables.
/// </summary>
public interface IJsonPathBindings
{
    /// <summary>
    ///     When step: Extracts a value from a JSON variable via JSONPath and stores it as a new variable (stringified).
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    /// <param name="targetVariableName">The name of the variable to set with the extracted value.</param>
    void SetVariableFromJsonPath(string jPath, string sourceVariableName, string targetVariableName);
}