using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing DateTime variables by adding or subtracting a TimeSpan, and computing
///     differences.
/// </summary>
[Binding]
public class DateTimeVariableManipulationBindings : IDateTimeVariableManipulationBindings
{
    private readonly IDateTimeLogic _dateTimeLogic;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DateTimeVariableManipulationBindings" /> class.
    /// </summary>
    /// <param name="dateTimeLogic">Logic component for DateTime operations.</param>
    public DateTimeVariableManipulationBindings(IDateTimeLogic dateTimeLogic)
    {
        _dateTimeLogic = dateTimeLogic;
    }

    /// <summary>
    ///     When step: Adds the provided timespan to the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to add (e.g., "01:30:00" for 1h30m).</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is added to the value of variable '(.*)'")]
    public void AddTimeSpanToVariable(string timeSpan, string variableName)
    {
        _dateTimeLogic.AddTimeSpanToVariable(timeSpan, variableName);
    }

    /// <summary>
    ///     When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractTimeSpanFromVariable(string timeSpan, string variableName)
    {
        _dateTimeLogic.SubtractTimeSpanFromVariable(timeSpan, variableName);
    }

    /// <summary>
    ///     When step: Subtracts the provided date/time value from the current DateTime stored in the specified variable and
    ///     stores the difference as a constant format string.
    /// </summary>
    /// <param name="dateToSubstract">The date/time string to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the date '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName)
    {
        _dateTimeLogic.SubtractDateTimeFromDateTime(dateToSubstract, variableName);
    }
}