namespace NatLaRestTest.Bindings.Drivers.Interfaces;

/// <summary>
/// Provides operations to parse and manipulate <see cref="DateTime"/> and <see cref="TimeSpan"/> values.
/// </summary>
public interface IDateTimeManipulationDriver
{
    /// <summary>
    /// Adds a <see cref="TimeSpan"/> to a <see cref="DateTime"/> and returns an invariant string.
    /// </summary>
    /// <param name="currentDate">The current date/time.</param>
    /// <param name="delta">The timespan to add.</param>
    /// <returns>The resulting date/time as invariant string.</returns>
    string AddTimeSpanToDateTime(DateTime currentDate, TimeSpan delta);

    /// <summary>
    /// Subtracts a <see cref="TimeSpan"/> from a <see cref="DateTime"/> and returns an invariant string.
    /// </summary>
    /// <param name="currentDate">The current date/time.</param>
    /// <param name="delta">The timespan to subtract.</param>
    /// <returns>The resulting date/time as invariant string.</returns>
    string SubtractTimeSpanFromDateTime(DateTime currentDate, TimeSpan delta);

    /// <summary>
    /// Parses a string into a <see cref="DateTime"/> using invariant culture.
    /// </summary>
    /// <param name="variableValue">The string representation of the date/time.</param>
    /// <returns>The parsed <see cref="DateTime"/>.</returns>
    DateTime ParseDate(string variableValue);

    /// <summary>
    /// Parses a string into a <see cref="TimeSpan"/> using invariant culture.
    /// </summary>
    /// <param name="timeSpan">The string representation of the timespan.</param>
    /// <returns>The parsed <see cref="TimeSpan"/>.</returns>
    TimeSpan ParseTimeSpan(string timeSpan);

    /// <summary>
    /// Subtracts one <see cref="DateTime"/> from another and returns a constant format string.
    /// </summary>
    /// <param name="currentDate">The base date/time.</param>
    /// <param name="dateToSubtract">The date/time to subtract.</param>
    /// <returns>The difference as a <c>c</c> format string.</returns>
    string SubtractDateTimeFromDateTime(DateTime currentDate, DateTime dateToSubtract);
}