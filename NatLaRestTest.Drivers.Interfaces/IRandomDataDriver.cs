using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
///     Provides methods to generate random numbers and strings for test data.
/// </summary>
public interface IRandomDataDriver
{
    /// <summary>
    ///     Returns a random double value between the specified inclusive range.
    /// </summary>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>A random <see cref="double" /> between <paramref name="minValue" /> and <paramref name="maxValue" />.</returns>
    double GetDoubleInRange(double minValue, double maxValue);

    /// <summary>
    ///     Returns a random integer value between the specified half-open range [min, max).
    /// </summary>
    /// <param name="minValue">The inclusive minimum.</param>
    /// <param name="maxValue">The exclusive maximum.</param>
    /// <returns>A random <see cref="int" /> in the specified range.</returns>
    int GetIntegerInRange(int minValue, int maxValue);

    /// <summary>
    ///     Returns a random string based on the requested faker type.
    /// </summary>
    /// <param name="stringType">The type of string to generate.</param>
    /// <returns>A randomly generated string.</returns>
    string GetRandomString(FakerStringType stringType);
}