using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings that perform string operations and store results in scenario variables.
/// </summary>
[Binding]
public class StringOperationBindings(IStringDriver stringDriver) : IStringOperationBindings
{
    /// <summary>
    ///     When step: Extracts a substring from the provided input string using the given start index and length,
    ///     then stores the result in the specified target variable.
    /// </summary>
    /// <param name="startIndex">The zero-based starting index of the substring.</param>
    /// <param name="length">The number of characters to include in the substring.</param>
    /// <param name="input">The source string to extract from.</param>
    /// <param name="targetVariableName">The name of the variable where the substring will be stored.</param>
    [When("the substring from index '(.*)' and length '(.*)' is extracted from '(.*)' and stored in variable '(.*)'")]
    public void GetSubString(int startIndex, int length, string input, string targetVariableName) =>
        stringDriver.GetSubString(startIndex, length, input, targetVariableName);

    /// <summary>
    ///     When step: Stores the length of the given input string in the specified target variable.
    /// </summary>
    /// <param name="input">The input string to measure.</param>
    /// <param name="targetVariableName">The name of the variable where the length will be stored.</param>
    [When("the length of string '(.*)' is stored in variable '(.*)'")]
    public void GetStringLength(string input, string targetVariableName) =>
        stringDriver.GetStringLength(input, targetVariableName);
}