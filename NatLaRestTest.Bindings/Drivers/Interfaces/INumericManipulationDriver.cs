namespace NatLaRestTest.Bindings.Drivers.Interfaces;

/// <summary>
/// Provides numeric parsing/manipulation utilities for variables.
/// </summary>
public interface INumericManipulationDriver
{
    /// <summary>
    /// Parses a string into a double using invariant culture.
    /// </summary>
    /// <param name="current">The input value to parse.</param>
    /// <returns>The parsed double.</returns>
    double Parse(string? current);
}