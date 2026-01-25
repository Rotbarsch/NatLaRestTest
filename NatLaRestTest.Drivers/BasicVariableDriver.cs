using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides basic operations on scenario variables, including setting and null checks.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BasicVariableDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to store and retrieve scenario variables.</param>
public class BasicVariableDriver(IVariableService variableService) : IBasicVariableDriver
{

    /// <summary>
    /// Sets the value of a scenario variable.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variableValue">The value to store.</param>
    public void SetVariable(string variableName, string? variableValue)
    {
        variableService.SetVariable(variableName, variableValue);
    }

    /// <summary>
    /// Asserts that the specified scenario variable is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNull(string variableName)
    {
        var value = variableService.GetVariable(variableName);
        Assert.IsNull(value, $"Variable '{variableName}' is not null.");
    }

    /// <summary>
    /// Asserts that the specified scenario variable is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    public void AssertVariableIsNotNull(string variableName)
    {
        var value = variableService.GetVariable(variableName);
        Assert.IsNotNull(value, $"Variable '{variableName}' is null.");
    }
}