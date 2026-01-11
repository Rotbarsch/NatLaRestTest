using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions.ManipulateVariableActions;

/// <summary>
/// Step bindings for manipulating existing DateTime variables by adding or subtracting a TimeSpan, and computing differences.
/// </summary>
[Binding]
public class DateTimeVariableManipulationBindings
{
    private readonly IVariableDriver _variableDriver;
    private readonly IDateTimeManipulationDriver _dateTimeManipulationDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeVariableManipulationBindings"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver used to get and set variable values.</param>
    /// <param name="dateTimeManipulationDriver">The driver providing DateTime and TimeSpan operations.</param>
    public DateTimeVariableManipulationBindings(IVariableDriver variableDriver, IDateTimeManipulationDriver dateTimeManipulationDriver)
    {
        _variableDriver = variableDriver;
        _dateTimeManipulationDriver = dateTimeManipulationDriver;
    }

    /// <summary>
    /// When step: Adds the provided timespan to the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to add (e.g., "01:30:00" for 1h30m).</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is added to the value of variable '(.*)'")]
    public void AddTimeSpanToVariable(string timeSpan, string variableName)
    {
        var variableValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(variableValue, $"Variable '{variableName}' returned null.");
        var currentDate = _dateTimeManipulationDriver.ParseDate(variableValue!);
        var delta = _dateTimeManipulationDriver.ParseTimeSpan(timeSpan);
        var result = _dateTimeManipulationDriver.AddTimeSpanToDateTime(currentDate,delta);
        _variableDriver.SetVariable(variableName, result);
    }

    /// <summary>
    /// When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.
    /// </summary>
    /// <param name="timeSpan">The timespan to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the timespan '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractTimeSpanFromVariable(string timeSpan, string variableName)
    {
        var variableValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(variableValue, $"Variable '{variableName}' returned null.");
        var currentDate = _dateTimeManipulationDriver.ParseDate(variableValue!);
        var delta = _dateTimeManipulationDriver.ParseTimeSpan(timeSpan);
        var result = _dateTimeManipulationDriver.SubtractTimeSpanFromDateTime(currentDate, delta);
        _variableDriver.SetVariable(variableName, result);
    }

    /// <summary>
    /// When step: Subtracts the provided date/time value from the current DateTime stored in the specified variable and stores the difference as a constant format string.
    /// </summary>
    /// <param name="dateToSubstract">The date/time string to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the date '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName)
    {
        var variableValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(variableValue);
        var currentDate = _dateTimeManipulationDriver.ParseDate(variableValue!);
        var dateToSubtract = _dateTimeManipulationDriver.ParseDate(dateToSubstract);
        var result = _dateTimeManipulationDriver.SubtractDateTimeFromDateTime(currentDate, dateToSubtract);
        _variableDriver.SetVariable(variableName, result);
    }
}