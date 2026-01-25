using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides assertions for boolean scenario variables.
/// </summary>
/// <param name="variableService">Service used to retrieve scenario variables.</param>
/// <param name="boolService">Service used to handle boolean variables.</param>
public class BoolVariableDriver(IVariableService variableService, IBoolService boolService) : IBoolVariableDriver
{
    /// <summary>
    /// Asserts that the specified scenario variable represents the expected boolean value.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    /// <param name="boolean">The expected boolean value.</param>
    public void AssertVariableIs(string variableName, bool boolean)
    {
        var value = variableService.GetVariable(variableName);
        boolService.AreBooleanEqual(boolean, value);
    }
}