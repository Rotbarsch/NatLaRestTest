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
    /// When steps: Formats a datetime and stores the resulting string in a specified variable.
    /// </summary>
    /// <param name="dateTime">Input datetime.</param>
    /// <param name="targetVariableName">Variable to store the result in.</param>
    /// <param name="format">.NET format of the string, eg. YYMMDD</param>
    void SaveFormattedDateTime(string dateTime, string targetVariableName, string format);
}