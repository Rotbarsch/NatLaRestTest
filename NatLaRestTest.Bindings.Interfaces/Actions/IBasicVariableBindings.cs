namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings for setting scenario variables to explicit string values (single line or multiline).
/// </summary>
public interface IBasicVariableBindings
{
    /// <summary>
    ///     When step: Sets the specified scenario variable to the provided string value.
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    void SetVariableManually(string value, string variableName);

    /// <summary>
    ///     When step: Sets the specified scenario variable to the provided multiline string value.
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    void SetVariableManuallyMultiline(string variableName, string value);
}