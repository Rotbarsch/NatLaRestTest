using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing basic assertions on scenario variables (null/not null).
/// </summary>
[Binding]
public class BasicVariableAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Step bindings providing basic assertions on scenario variables (null/not null).
    /// </summary>
    public BasicVariableAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the specified variable is null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is null")]
    public void AssertVariableIsNull(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName);
        Assert.IsNull(value, $"Variable '{variableName}' is not null.");
    }

    /// <summary>
    /// Then step: Asserts that the specified variable is not null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is not null")]
    public void AssertVariableIsNotNull(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName);
        Assert.IsNotNull(value, $"Variable '{variableName}' is null.");
    }
}