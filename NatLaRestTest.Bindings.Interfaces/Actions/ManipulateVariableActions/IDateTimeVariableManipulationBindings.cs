namespace NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;

public interface IDateTimeVariableManipulationBindings
{
    /// <summary>
    ///     When step: Adds the provided timespan to the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to add (e.g., "01:30:00" for 1h30m).</param>
    /// <param name="variableName">The target variable name.</param>
    void AddTimeSpanToVariable(string timeSpan, string variableName);

    /// <summary>
    ///     When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    void SubtractTimeSpanFromVariable(string timeSpan, string variableName);

    /// <summary>
    ///     When step: Subtracts the provided date/time value from the current DateTime stored in the specified variable and
    ///     stores the difference as a constant format string.
    /// </summary>
    /// <param name="dateToSubstract">The date/time string to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName);
}