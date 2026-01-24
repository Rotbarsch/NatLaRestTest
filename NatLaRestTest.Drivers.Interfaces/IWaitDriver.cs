namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Driver for wait interactions.
/// </summary>
public interface IWaitDriver
{
    /// <summary>
    /// Waits the specified number of seconds.
    /// </summary>
    /// <param name="timeInSeconds">Number of seconds to wait.</param>
    void Wait(double timeInSeconds);
}