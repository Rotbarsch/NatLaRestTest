using System;
using System.Globalization;

namespace NatLaRestTest.Services.Extensions;

/// <summary>
///     Extension methods for <see cref="DateTime" /> related formatting.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    ///     Converts a <see cref="DateTime" /> to an invariant culture ISO 8601 string (round-trip format).
    /// </summary>
    /// <param name="dt">The date/time value.</param>
    /// <param name="cultureInfo">The culture information to use for formatting.</param>
    /// <returns>The formatted string using the "O" format and invariant culture.</returns>
    public static string ToInvariantDateTimeString(this DateTime dt, CultureInfo cultureInfo)
    {
        return dt.ToString("O", cultureInfo);
    }
}