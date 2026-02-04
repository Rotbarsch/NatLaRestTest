using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

/// <summary>
/// Service for interrupting test execution for a specified duration.
/// </summary>
public class WaitService : IWaitService
{
    /// <summary>
    /// Waits the specified number of seconds.
    /// </summary>
    /// <param name="seconds">Amount of seconds to wait.</param>
    public void Wait(double seconds)
    {
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
}