namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Service for interrupting test execution for a specified duration.
/// </summary>
public interface IWaitService
{
    /// <summary>
    /// Waits the specified number of seconds.
    /// </summary>
    /// <param name="seconds">Amount of seconds to wait.</param>
    void Wait(double seconds);
}