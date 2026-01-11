using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions.ManipulateVariableActions;

/// <summary>
/// Step bindings for manipulating existing string variables by appending, prepending, or replacing content.
/// </summary>
[Binding]
public class StringVariableManipulationBindings
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Step bindings for manipulating existing string variables by appending, prepending, or replacing content.
    /// </summary>
    public StringVariableManipulationBindings(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// When step: Appends a literal string to the end of the specified variable's current value.
    /// </summary>
    /// <param name="valueToAppend">The string to append.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is appended to the value of variable '(.*)'")]
    public void AppendStringToVariable(string valueToAppend, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        _variableDriver.SetVariable(variableName, current + valueToAppend);
    }

    /// <summary>
    /// When step: Prepends a literal string to the beginning of the specified variable's current value.
    /// </summary>
    /// <param name="valueToPrepend">The string to prepend.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is prepended to the value of variable '(.*)'")]
    public void PrependStringToVariable(string valueToPrepend, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        _variableDriver.SetVariable(variableName, valueToPrepend + current);
    }

    /// <summary>
    /// When step: Replaces all occurrences of a substring with another within the specified variable's value.
    /// </summary>
    /// <param name="oldValue">The substring to replace.</param>
    /// <param name="newValue">The replacement string.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is replaced with '(.*)' in the value of variable '(.*)'")]
    public void ReplaceStringInVariable(string oldValue, string newValue, string variableName)
    {
        var current = _variableDriver.GetVariable(variableName);
        Assert.NotNull(current);
        _variableDriver.SetVariable(variableName, current!.Replace(oldValue, newValue));
    }
}