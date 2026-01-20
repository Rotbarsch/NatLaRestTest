namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings for setting scenario variables to explicit string values (single line or multiline).
/// </summary>
public interface IBasicVariableBindings
{
    void SetVariableManually(string value, string variableName);
    void SetVariableManuallyMultiline(string variableName, string value);
}