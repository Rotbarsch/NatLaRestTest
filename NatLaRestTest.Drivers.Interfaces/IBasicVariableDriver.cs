namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Provides basic operations for setting and asserting variable values.
/// </summary>
public interface IBasicVariableDriver
{
    /// <summary>
    /// Sets the value of a variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to set.</param>
    void SetVariable(string variableName, string variableValue);

    /// <summary>
    /// Asserts that the specified variable value is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    void AssertVariableIsNull(string variableName);

    /// <summary>
    /// Asserts that the specified variable value is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    void AssertVariableIsNotNull(string variableName);
}