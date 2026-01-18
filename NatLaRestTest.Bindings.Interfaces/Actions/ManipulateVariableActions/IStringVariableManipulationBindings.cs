namespace NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;

public interface IStringVariableManipulationBindings
{
    /// <summary>
    ///     When step: Appends a literal string to the end of the specified variable's current value.
    /// </summary>
    /// <param name="valueToAppend">The string to append.</param>
    /// <param name="variableName">The target variable name.</param>
    void AppendStringToVariable(string valueToAppend, string variableName);

    /// <summary>
    ///     When step: Prepends a literal string to the beginning of the specified variable's current value.
    /// </summary>
    /// <param name="valueToPrepend">The string to prepend.</param>
    /// <param name="variableName">The target variable name.</param>
    void PrependStringToVariable(string valueToPrepend, string variableName);

    /// <summary>
    ///     When step: Replaces all occurrences of a substring with another within the specified variable's value.
    /// </summary>
    /// <param name="oldValue">The substring to replace.</param>
    /// <param name="newValue">The replacement string.</param>
    /// <param name="variableName">The target variable name.</param>
    void ReplaceStringInVariable(string oldValue, string newValue, string variableName);
}