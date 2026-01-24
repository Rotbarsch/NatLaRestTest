using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings for pausing test execution.
/// </summary>
[Binding]
public class WaitBindings(IWaitDriver waitDriver) : IWaitBindings
{
    /// <summary>
    /// When step: Pauses test execution for the specified number of seconds.
    /// </summary>
    /// <param name="secondsToWait">Amount of seconds to wait.</param>
    [When("test execution is paused for '(.*)' seconds")]
    public void Wait(double secondsToWait)
    {
        waitDriver.Wait(secondsToWait);
    }
}