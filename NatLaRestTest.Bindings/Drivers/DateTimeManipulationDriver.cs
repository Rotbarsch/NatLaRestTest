using System.Globalization;
using NatLaRestTest.Bindings.Drivers.Extensions;
using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Bindings.Drivers;

/// <summary>
/// Driver providing parsing and arithmetic operations for <see cref="DateTime"/> and <see cref="TimeSpan"/> values.
/// </summary>
public class DateTimeManipulationDriver : IDateTimeManipulationDriver
{
    /// <inheritdoc />
    public string AddTimeSpanToDateTime(DateTime currentDate, TimeSpan delta)
    {
        return currentDate.Add(delta).ToInvariantDateTimeString();
    }

    /// <inheritdoc />
    public string SubtractTimeSpanFromDateTime(DateTime currentDate, TimeSpan delta)
    {
        return currentDate.Subtract(delta).ToInvariantDateTimeString();
    }

    /// <summary>
    /// Parses an invariant date/time string into a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="variableValue">The string to parse.</param>
    /// <returns>The parsed <see cref="DateTime"/>.</returns>
    public DateTime ParseDate(string variableValue)
    {

        if (DateTime.TryParse(variableValue, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
        {
            return dt;
        }

        Assert.Fail($"Value '{variableValue}' is not a valid DateTime.");
        throw new InvalidOperationException();

    }

    /// <summary>
    /// Parses an invariant timespan string into a <see cref="TimeSpan"/>.
    /// </summary>
    /// <param name="timeSpan">The string to parse.</param>
    /// <returns>The parsed <see cref="TimeSpan"/>.</returns>
    public TimeSpan ParseTimeSpan(string timeSpan)
    {
        if (TimeSpan.TryParse(timeSpan, CultureInfo.InvariantCulture, out var ts))
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