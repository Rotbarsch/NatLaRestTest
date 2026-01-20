using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides assertions for boolean scenario variables.
/// </summary>
/// <param name="variableDriver">Driver used to retrieve scenario variables.</param>
public class BoolVariableLogic(IVariableDriver variableDriver, IBoolDriver boolDriver) : IBoolVariableLogic
{
    /// <summary>
    /// Asserts that the specified scenario variable represents the expected boolean value.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    /// <param name="boolean">The expected boolean value.</param>
    public void AssertVariableIs(string variableName, bool boolean)
    {
        var value = variableDriver.GetVariable(variableName);
        boolDriver.AreBooleanEqual(boolean, value);
    }
}