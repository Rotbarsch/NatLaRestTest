using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions.SetVariableActions;

/// <summary>
/// Step bindings for storing date/time based values into scenario variables.
/// </summary>
[Binding]
public class DateTimeVariableBindings
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeVariableBindings"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver used to store values.</param>
    public DateTimeVariableBindings(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// When step: Stores the current date/time as a string in the specified variable using the system default format.
    /// </summary>
    /// <param name="variableName">The variable name to store the current date/time into.</param>
    [When("^the current date is stored in variable '([^']+)'$")]
    public void SetCurrentDate(string variableName)
    {
        _variableDriver.SetVariable(variableName, DateTime.Now.ToString());
    }

    /// <summary>
    /// When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time format string.
    /// </summary>
    /// <param name="variableName">The variable name to store the formatted date/time into.</param>
    /// <param name="dateFormat">A .NET date/time format string (e.g., "yyyy-MM-dd").</param>
    [When("^the current date is stored in variable '([^']+)' in format '([^']+)'$")]
    public void SetCurrentDateFormatted(string variableName, string dateFormat)
    {
        _variableDriver.SetVariable(variableName, DateTime.Now.ToString(dateFormat));
    }
}