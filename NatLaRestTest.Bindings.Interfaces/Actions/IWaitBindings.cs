namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Step bindings for pausing test execution.
/// </summary>
public interface IWaitBindings
{
    /// <summary>
    /// When step: Pauses test execution for the specified number of seconds.
    /// </summary>
    /// <param name="secondsToWaitAsString">Amount of seconds to wait.</param>
    void Wait(string secondsToWaitAsString);
}