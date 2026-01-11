using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for setting scenario variables to explicit string values (single line or multiline).
/// </summary>
[Binding]
public class BasicVariableBindings
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicVariableBindings"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver used to store values.</param>
    public BasicVariableBindings(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// When step: Sets the specified scenario variable to the provided string value.
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    [When("the value '(.*)' is stored in variable '(.*)'")]
    public void SetVariableManually(string value, string variableName)
    {
        _variableDriver.SetVariable(variableName, value);
    }

    /// <summary>
    /// When step: Sets the specified scenario variable to the provided multiline string value.
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    [When("the following value is stored in variable '(.*)':")]
    public void SetVariableManuallyMultiline(string variableName, string value)
    {
        _variableDriver.SetVariable(variableName, value);
    }
}