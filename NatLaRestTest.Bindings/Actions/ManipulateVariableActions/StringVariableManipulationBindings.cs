using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing string variables by appending, prepending, or replacing content.
/// </summary>
[Binding]
public class StringVariableManipulationBindings : IStringVariableManipulationBindings
{
    private readonly IStringLogic _stringLogic;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringVariableManipulationBindings" /> class.
    /// </summary>
    /// <param name="stringLogic">Logic component used to perform string manipulations.</param>
    public StringVariableManipulationBindings(IStringLogic stringLogic)
    {
        _stringLogic = stringLogic;
    }

    /// <summary>
    ///     When step: Appends a literal string to the end of the specified variable's current value.
    /// </summary>
    /// <param name="valueToAppend">The string to append.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is appended to the value of variable '(.*)'")]
    public void AppendStringToVariable(string valueToAppend, string variableName)
    {
        _stringLogic.AppendStringToVariable(valueToAppend, variableName);
    }

    /// <summary>
    ///     When step: Prepends a literal string to the beginning of the specified variable's current value.
    /// </summary>
    /// <param name="valueToPrepend">The string to prepend.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the string '(.*)' is prepended to the value of variable '(.*)'")]
    public void PrependStringToVariable(string valueToPrepend, string variableName)
    {
        _stringLogic.PrependStringToVariable(valueToPrepend, variableName);
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
        _stringLogic.ReplaceStringInVariable(oldValue, newValue, variableName);
    }
}