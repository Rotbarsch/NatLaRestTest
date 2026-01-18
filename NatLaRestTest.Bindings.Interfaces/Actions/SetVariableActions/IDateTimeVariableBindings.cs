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
}