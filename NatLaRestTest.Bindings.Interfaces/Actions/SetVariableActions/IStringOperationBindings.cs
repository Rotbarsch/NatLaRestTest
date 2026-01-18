namespace NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;

public interface IStringOperationBindings
{
    /// <summary>
    ///     When step: Extracts a substring from the provided input string using the given start index and length,
    ///     then stores the result in the specified target variable.
    /// </summary>
    /// <param name="startIndex">The zero-based starting index of the substring.</param>
    /// <param name="length">The number of characters to include in the substring.</param>
    /// <param name="input">The source string to extract from.</param>
    /// <param name="targetVariableName">The name of the variable where the substring will be stored.</param>
    void GetSubString(int startIndex, int length, string input, string targetVariableName);

    /// <summary>
    ///     When step: Stores the length of the given input string in the specified target variable.
    /// </summary>
    /// <param name="input">The input string to measure.</param>
    /// <param name="targetVariableName">The name of the variable where the length will be stored.</param>
    void GetStringLength(string input, string targetVariableName);
}