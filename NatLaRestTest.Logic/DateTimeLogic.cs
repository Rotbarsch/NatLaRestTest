using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides operations to manipulate and assert on <see cref="DateTime"/> values stored in scenario variables.
/// </summary>
public class DateTimeLogic : IDateTimeLogic
{
    private readonly IDateTimeManipulationDriver _dateTimeManipulationDriver;
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to access scenario variables.</param>
    /// <param name="dateTimeManipulationDriver">Driver used to parse and manipulate date/time values.</param>
    public DateTimeLogic(IVariableDriver variableDriver, IDateTimeManipulationDriver dateTimeManipulationDriver)
    {
        _variableDriver = variableDriver;
        _dateTimeManipulationDriver = dateTimeManipulationDriver;
    }

    /// <summary>
    /// Adds the provided time span to the <see cref="DateTime"/> value stored in the variable.
    /// </summary>
    /// <param name="timeSpan">Time span to add (parsable by the driver).</param>
    /// <param name="variableName">Variable containing a date/time string.</param>
    public void AddTimeSpanToVariable(string timeSpan, string variableName)
    {
        var variableValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(variableValue, $"Variable '{variableName}' returned null.");
        var currentDate = _dateTimeManipulationDriver.ParseDate(variableValue!);
        var delta = _dateTimeManipulationDriver.ParseTimeSpan(timeSpan);
        var result = _dateTimeManipulationDriver.AddTimeSpanToDateTime(currentDate, delta);
        _variableDriver.SetVariable(variableName, result);
    }

    /// <summary>
    /// Subtracts the provided time span from the <see cref="DateTime"/> value stored in the variable.
    /// </summary>
    /// <param name="timeSpan">Time span to subtract (parsable by the driver).</param>
    /// <param name="variableName">Variable containing a date/time string.</param>
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
    /// Subtracts a provided date/time from the variable's date/time value and stores the result.
    /// </summary>
    /// <param name="dateToSubstract">The date/time to subtract.</param>
    /// <param name="variableName">Variable name containing a date/time string.</param>
    public void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName)
    {
        var variableValue = _variableDriver.GetVariable(variableName);
        Assert.NotNull(variableValue);
        var currentDate = _dateTimeManipulationDriver.ParseDate(variableValue!);
        var dateToSubtract = _dateTimeManipulationDriver.ParseDate(dateToSubstract);
        var result = _dateTimeManipulationDriver.SubtractDateTimeFromDateTime(currentDate, dateToSubtract);
        _variableDriver.SetVariable(variableName, result);
    }

    /// <summary>
    /// Sets the current system date/time as a string in the specified variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    public void SetCurrentDate(string variableName)
    {
        _variableDriver.SetVariable(variableName, DateTime.Now.ToString());
    }

    /// <summary>
    /// Sets the current system date/time formatted according to the provided format string.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    /// <param name="dateFormat">Format string passed to <see cref="DateTime.ToString(string?)"/>.</param>
    public void SetCurrentDateFormatted(string variableName, string dateFormat)
    {
        _variableDriver.SetVariable(variableName, DateTime.Now.ToString(dateFormat));
    }
}