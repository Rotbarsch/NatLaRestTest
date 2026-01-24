namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Provides operations to manipulate and store date/time values in variables.
/// </summary>
public interface IDateTimeDriver
{
    /// <summary>
    /// Adds a parsed <see cref="System.TimeSpan"/> to the current date stored in a variable.
    /// </summary>
    /// <param name="timeSpan">The time span string (invariant format).</param>
    /// <param name="variableName">Target variable to store the resulting date/time.</param>
    void AddTimeSpanToVariable(string timeSpan, string variableName);

    /// <summary>
    /// Subtracts a parsed <see cref="System.TimeSpan"/> from the current date stored in a variable.
    /// </summary>
    /// <param name="timeSpan">The time span string (invariant format).</param>
    /// <param name="variableName">Target variable to store the resulting date/time.</param>
    void SubtractTimeSpanFromVariable(string timeSpan, string variableName);

    /// <summary>
    /// Subtracts a parsed <see cref="System.DateTime"/> from the current date stored in a variable and stores the result as a duration.
    /// </summary>
    /// <param name="dateToSubstract">The date/time string to subtract.</param>
    /// <param name="variableName">Target variable to store the resulting <see cref="System.TimeSpan"/>.</param>
    void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName);

    /// <summary>
    /// Stores the current date/time in the specified variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    void SetCurrentDate(string variableName);

    /// <summary>
    /// Stores the current date/time formatted using the provided format string in the specified variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    /// <param name="dateFormat">Date/time format string.</param>
    void SetCurrentDateFormatted(string variableName, string dateFormat);
}