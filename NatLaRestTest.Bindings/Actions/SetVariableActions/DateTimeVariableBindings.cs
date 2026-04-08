using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings for storing date/time based values into scenario variables.
/// </summary>
[Binding]
public class DateTimeVariableBindings(IDateTimeDriver dateTimeDriver) : IDateTimeVariableBindings
{
    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the system default format.
    /// </summary>
    /// <param name="variableName">The variable name to store the current date/time into.</param>
    [When("^the current date is stored in variable '([^']+)'$")]
    public void SetCurrentDate(string variableName) =>
        dateTimeDriver.SetCurrentDate(variableName);

    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time
    ///     format string.
    /// </summary>
    /// <param name="variableName">The variable name to store the formatted date/time into.</param>
    /// <param name="dateFormat">A .NET date/time format string (e.g., "yyyy-MM-dd").</param>
    [When("^the current date is stored in variable '([^']+)' in format '([^']+)'$")]
    public void SetCurrentDateFormatted(string variableName, string dateFormat) =>
        dateTimeDriver.SetCurrentDateFormatted(variableName, dateFormat);

    /// <summary>
    /// When step: Extracts a specific component (e.g., year, month, day) from the provided date and stores it as a string in the specified variable.
    ///
    /// The following components are currently supported:
    /// Ticks,
    /// Date,
    /// Day,
    /// DayOfWeek,
    /// DayOfYear,
    /// Hour,
    /// Microsecond,
    /// Millisecond,
    /// Minute,
    /// Month,
    /// NanoSecond,
    /// Second,
    /// TimeOfDay,
    /// Year
    /// </summary>
    /// <param name="dateTimeComponent">Component to extract.</param>
    /// <param name="date">Date to operate on.</param>
    /// <param name="variableName">Name of variable to store result in.</param>
    [When("^the '(.*)' component of '([^']+)' is stored in variable '([^']+)'$")]
    public void GetComponentOfDate(DateComponent dateTimeComponent, string? date, string variableName) =>    
        dateTimeDriver.SetDateComponent(dateTimeComponent, date, variableName);    
}