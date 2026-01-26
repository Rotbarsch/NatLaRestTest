using System;
using System.Globalization;
using NatLaRestTest.Services.Extensions;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Service providing parsing and arithmetic operations for <see cref="DateTime" /> and <see cref="TimeSpan" /> values.
/// </summary>
/// <param name="cultureInfoService">Service for getting configured CultureInfo.</param>
public class DateTimeManipulationService(ICultureInfoService cultureInfoService) : IDateTimeManipulationService
{
    /// <inheritdoc />
    public string AddTimeSpanToDateTime(DateTime currentDate, TimeSpan delta)
    {
        return currentDate.Add(delta).ToInvariantDateTimeString(cultureInfoService.GetConfiguredCultureInfo());
    }

    /// <inheritdoc />
    public string SubtractTimeSpanFromDateTime(DateTime currentDate, TimeSpan delta)
    {
        return currentDate.Subtract(delta).ToInvariantDateTimeString(cultureInfoService.GetConfiguredCultureInfo());
    }

    /// <summary>
    ///     Parses an invariant date/time string into a <see cref="DateTime" />.
    /// </summary>
    /// <param name="variableValue">The string to parse.</param>
    /// <returns>The parsed <see cref="DateTime" />.</returns>
    public DateTime ParseDate(string variableValue)
    {
        if (DateTime.TryParse(variableValue, cultureInfoService.GetConfiguredCultureInfo(), DateTimeStyles.None, out var dt))
        {
            return dt;
        }

        Assert.Fail($"Value '{variableValue}' is not a valid DateTime.");
        throw new InvalidOperationException();
    }

    /// <summary>
    ///     Parses an invariant timespan string into a <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="timeSpan">The string to parse.</param>
    /// <returns>The parsed <see cref="TimeSpan" />.</returns>
    public TimeSpan ParseTimeSpan(string timeSpan)
    {
        if (TimeSpan.TryParse(timeSpan, cultureInfoService.GetConfiguredCultureInfo(), out var ts))
        {
            return ts;
        }

        Assert.Fail($"Value '{timeSpan}' is not a valid TimeSpan.");
        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public string SubtractDateTimeFromDateTime(DateTime currentDate, DateTime dateToSubtract)
    {
        return currentDate.Subtract(dateToSubtract).ToString("c");
    }
}