using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides basic operations on scenario variables, including setting and null checks.
/// </summary>
public class BasicVariableLogic : IBasicVariableLogic
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicVariableLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to store and retrieve scenario variables.</param>
    public BasicVariableLogic(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Sets the value of a scenario variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    public void SetVariable(string variableName, string variableValue)
    {
        _variableDriver.SetVariable(variableName, variableValue);
    }

    /// <summary>
    /// Asserts that the specified scenario variable is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNull(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName);
        Assert.IsNull(value, $"Variable '{variableName}' is not null.");
    }

    /// <summary>
    /// Asserts that the specified scenario variable is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNotNull(string variableName)
    {
        var value = _variableDriver.GetVariable(variableName);
        Assert.IsNotNull(value, $"Variable '{variableName}' is null.");
    }
}