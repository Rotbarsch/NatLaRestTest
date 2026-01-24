using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings for setting scenario variables to explicit string values (single line or multiline).
/// </summary>
[Binding]
public class BasicVariableBindings : IBasicVariableBindings
{
    private readonly IBasicVariableDriver _basicVariableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicVariableBindings"/> class.
    /// </summary>
    /// <param name="basicVariableDriver">Driver component used to set variables.</param>
    public BasicVariableBindings(IBasicVariableDriver basicVariableDriver)
    {
        _basicVariableDriver = basicVariableDriver;
    }

    /// <summary>
    /// When step: Sets the specified scenario variable to the provided string value.
    /// Set variables can be resolved in every binding parameter (multi-line or enclosed in single quotes) using the syntax: $(variableName).
    /// </summary>
    /// <param name="value">The value to assign to the variable.</param>
    /// <param name="variableName">The name of the variable to set.</param>
    [When("the value '(.*)' is stored in variable '(.*)'")]
    public void SetVariableManually(string value, string variableName) =>
        _basicVariableDriver.SetVariable(variableName, value);

    /// <summary>
    /// When step: Sets the specified scenario variable to the provided multiline string value.
    /// Set variables can be resolved in every binding parameter (multi-line or enclosed in single quotes) using the syntax: $(variableName).
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    [When("the following value is stored in variable '(.*)':")]
    public void SetVariableManuallyMultiline(string variableName, string value) =>
        _basicVariableDriver.SetVariable(variableName, value);
}