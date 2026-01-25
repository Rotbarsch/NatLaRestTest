using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing string variables by appending, prepending, or replacing content.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="StringVariableManipulationBindings" /> class.
/// </remarks>
/// <param name="stringDriver">Driver component used to perform string manipulations.</param>
[Binding]
public class StringVariableManipulationBindings(IStringDriver stringDriver) : IStringVariableManipulationBindings
{

    /// <summary>
    ///     When step: Appends a literal string to the end of the specified variable's current value.
    /// </summary>
    /// <param name="valueToAppend">The string to append.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is appended to the value of variable '(.*)'")]
    public void AppendStringToVariable(string valueToAppend, string variableName)
    {
        stringDriver.AppendStringToVariable(valueToAppend, variableName);
    }

    /// <summary>
    ///     When step: Prepends a literal string to the beginning of the specified variable's current value.
    /// </summary>
    /// <param name="valueToPrepend">The string to prepend.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is prepended to the value of variable '(.*)'")]
    public void PrependStringToVariable(string valueToPrepend, string variableName)
    {
        stringDriver.PrependStringToVariable(valueToPrepend, variableName);
    }

    /// <summary>
    ///     When step: Replaces all occurrences of a substring with another within the specified variable's value.
    /// </summary>
    /// <param name="oldValue">The substring to replace.</param>
    /// <param name="newValue">The replacement string.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is replaced with '(.*)' in the value of variable '(.*)'")]
    public void ReplaceStringInVariable(string oldValue, string newValue, string variableName)
    {
        stringDriver.ReplaceStringInVariable(oldValue, newValue, variableName);
    }
}