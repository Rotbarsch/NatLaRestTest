using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings for storing date/time based values into scenario variables.
/// </summary>
[Binding]
public class DateTimeVariableBindings(IDateTimeLogic dateTimeLogic) : IDateTimeVariableBindings
{
    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the system default format.
    /// </summary>
    /// <param name="variableName">The variable name to store the current date/time into.</param>
    [When("^the current date is stored in variable '([^']+)'$")]
    public void SetCurrentDate(string variableName) =>
        dateTimeLogic.SetCurrentDate(variableName);

    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time
    ///     format string.
    /// </summary>
    /// <param name="variableName">The variable name to store the formatted date/time into.</param>
    /// <param name="dateFormat">A .NET date/time format string (e.g., "yyyy-MM-dd").</param>
    [When("^the current date is stored in variable '([^']+)' in format '([^']+)'$")]
    public void SetCurrentDateFormatted(string variableName, string dateFormat) =>
        dateTimeLogic.SetCurrentDateFormatted(variableName, dateFormat);
}