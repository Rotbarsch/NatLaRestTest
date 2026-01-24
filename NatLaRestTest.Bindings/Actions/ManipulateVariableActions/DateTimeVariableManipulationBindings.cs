using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing DateTime variables by adding or subtracting a TimeSpan, and computing
///     differences.
/// </summary>
[Binding]
public class DateTimeVariableManipulationBindings : IDateTimeVariableManipulationBindings
{
    private readonly IDateTimeDriver _dateTimeDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DateTimeVariableManipulationBindings" /> class.
    /// </summary>
    /// <param name="dateTimeDriver">Driver component for DateTime operations.</param>
    public DateTimeVariableManipulationBindings(IDateTimeDriver dateTimeDriver)
    {
        _dateTimeDriver = dateTimeDriver;
    }

    /// <summary>
    ///     When step: Adds the provided timespan to the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to add (e.g., "01:30:00" for 1h30m).</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is added to the value of variable '(.*)'")]
    public void AddTimeSpanToVariable(string timeSpan, string variableName)
    {
        _dateTimeDriver.AddTimeSpanToVariable(timeSpan, variableName);
    }

    /// <summary>
    ///     When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractTimeSpanFromVariable(string timeSpan, string variableName)
    {
        _dateTimeDriver.SubtractTimeSpanFromVariable(timeSpan, variableName);
    }

    /// <summary>
    /// When steps: Formats a datetime and stores the resulting string in a specified variable.
    /// </summary>
    /// <param name="dateTime">Input datetime.</param>
    /// <param name="targetVariableName">Variable to store the result in.</param>
    /// <param name="format">.NET format of the string, eg. YYMMDD</param>
    [When("the date '(.*)' is stored in variable '(.*)' in format '(.*)'")]
    public void SaveFormattedDateTime(string dateTime, string targetVariableName, string format)
    {
        _dateTimeDriver.SaveDateTimeFormatted(dateTime, format, targetVariableName);
    }
}