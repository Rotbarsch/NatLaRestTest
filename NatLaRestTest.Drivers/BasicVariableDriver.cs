using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides basic operations on scenario variables, including setting and null checks.
/// </summary>
public class BasicVariableDriver : IBasicVariableDriver
{
    private readonly IVariableService _variableService;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicVariableDriver"/> class.
    /// </summary>
    /// <param name="variableService">Service used to store and retrieve scenario variables.</param>
    public BasicVariableDriver(IVariableService variableService)
    {
        _variableService = variableService;
    }

    /// <summary>
    /// Sets the value of a scenario variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    public void SetVariable(string variableName, string? variableValue)
    {
        _variableService.SetVariable(variableName, variableValue);
    }

    /// <summary>
    /// Asserts that the specified scenario variable is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNull(string variableName)
    {
        var value = _variableService.GetVariable(variableName);
        Assert.IsNull(value, $"Variable '{variableName}' is not null.");
    }

    /// <summary>
    /// Asserts that the specified scenario variable is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNotNull(string variableName)
    {
        var value = _variableService.GetVariable(variableName);
        Assert.IsNotNull(value, $"Variable '{variableName}' is null.");
    }
}