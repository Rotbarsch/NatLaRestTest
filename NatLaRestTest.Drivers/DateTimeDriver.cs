using System;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides operations to manipulate and assert on <see cref="DateTime"/> values stored in scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DateTimeDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
/// <param name="dateTimeManipulationService">Service used to parse and manipulate date/time values.</param>
public class DateTimeDriver(IVariableService variableService, IDateTimeManipulationService dateTimeManipulationService) : IDateTimeDriver
{

    /// <summary>
    /// Adds the provided time span to the <see cref="DateTime"/> value stored in the variable.
    /// </summary>
    /// <param name="timeSpan">Time span to add (parsable by the Service).</param>
    /// <param name="variableName">Variable containing a date/time string.</param>
    public void AddTimeSpanToVariable(string timeSpan, string variableName)
    {
        var variableValue = variableService.GetVariable(variableName);
        Assert.NotNull(variableValue, $"Variable '{variableName}' returned null.");
        var date = dateTimeManipulationService.ParseDate(variableValue!);
        var delta = dateTimeManipulationService.ParseTimeSpan(timeSpan);
        var result = dateTimeManipulationService.AddTimeSpanToDateTime(date, delta);
        variableService.SetVariable(variableName, result);
    }

    /// <summary>
    /// Subtracts the provided time span from the <see cref="DateTime"/> value stored in the variable.
    /// </summary>
    /// <param name="timeSpan">Time span to subtract (parsable by the Service).</param>
    /// <param name="variableName">Variable containing a date/time string.</param>
    public void SubtractTimeSpanFromVariable(string timeSpan, string variableName)
    {
        var variableValue = variableService.GetVariable(variableName);
        Assert.NotNull(variableValue, $"Variable '{variableName}' returned null.");
        var date = dateTimeManipulationService.ParseDate(variableValue!);
        var delta = dateTimeManipulationService.ParseTimeSpan(timeSpan);
        var result = dateTimeManipulationService.SubtractTimeSpanFromDateTime(date, delta);
        variableService.SetVariable(variableName, result);
    }

    /// <summary>
    /// Subtracts a provided date/time from the variable's date/time value and stores the result.
    /// </summary>
    /// <param name="dateToSubstract">The date/time to subtract.</param>
    /// <param name="variableName">Variable name containing a date/time string.</param>
    public void SubtractDateTimeFromDateTime(string dateToSubstract, string variableName)
    {
        var variableValue = variableService.GetVariable(variableName);
        Assert.NotNull(variableValue);
        var date = dateTimeManipulationService.ParseDate(variableValue!);
        var dateToSubtract = dateTimeManipulationService.ParseDate(dateToSubstract);
        var result = dateTimeManipulationService.SubtractDateTimeFromDateTime(date, dateToSubtract);
        variableService.SetVariable(variableName, result);
    }

    /// <summary>
    /// Sets the current system date/time as a string in the specified variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    public void SetCurrentDate(string variableName)
    {
        variableService.SetVariable(variableName, DateTime.Now.ToString("O"));
    }

    /// <summary>
    /// Sets the current system date/time formatted according to the provided format string.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    /// <param name="dateFormat">Format string passed to <see cref="DateTime.ToString(string?)"/>.</param>
    public void SetCurrentDateFormatted(string variableName, string dateFormat)
    {
        variableService.SetVariable(variableName, DateTime.Now.ToString(dateFormat));
    }

    public void SaveDateTimeFormatted(string dateTime, string format, string targetVariableName)
    {
        var date = dateTimeManipulationService.ParseDate(dateTime);
        variableService.SetVariable(targetVariableName,date.ToString(format));
    }
}