using System.Globalization;
using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Bindings.Drivers;

/// <summary>
/// Driver that parses numeric values from strings using invariant culture.
/// </summary>
public class NumericManipulationDriver : INumericManipulationDriver
{
    /// <inheritdoc />
    public double Parse(string? current)
    {

        Assert.NotNull(current, $"Cannot parse null.");
        var parsed=double.TryParse(current, NumberStyles.Float, CultureInfo.InvariantCulture, out var currentValue);
        Assert.IsTrue(parsed, $"The value '{current}' is not a valid number.");
        return currentValue;
    }
}