using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;

public interface IDateTimeVariableBindings
{
    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the system default format.
    /// </summary>
    /// <param name="variableName">The variable name to store the current date/time into.</param>
    void SetCurrentDate(string variableName);

    /// <summary>
    ///     When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time
    ///     format string.
    /// </summary>
    /// <param name="variableName">The variable name to store the formatted date/time into.</param>
    /// <param name="dateFormat">A .NET date/time format string (e.g., "yyyy-MM-dd").</param>
    void SetCurrentDateFormatted(string variableName, string dateFormat);

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
    void GetComponentOfDate(DateComponent dateTimeComponent, string? date, string variableName);
}