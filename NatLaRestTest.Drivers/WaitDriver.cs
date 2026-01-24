using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Driver for wait interactions.
/// </summary>
public class WaitDriver(IWaitService waitService) : IWaitDriver
{
    /// <summary>
    /// Waits the specified number of seconds.
    /// </summary>
    /// <param name="timeInSeconds">Number of seconds to wait.</param>
    public void Wait(double timeInSeconds)
    {
        waitService.Wait(timeInSeconds);
    }
}