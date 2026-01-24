using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings for Stopwatch setup.
/// </summary>
[Binding]
public class StopwatchBindings(IStopwatchDriver stopwatchDriver) : IStopwatchBindings
{
    /// <summary>
    /// When step: Creates and starts a new stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to create.</param>
    [When("a stopwatch named '(.*)' is started")]
    public void Start(string name)
    {
        stopwatchDriver.StartNew(name);
    }

    /// <summary>
    /// When step: Stops the stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to stop.</param>
    [When("the stopwatch '(.*)' is stopped")]
    public void Stop(string name)
    {
        stopwatchDriver.Stop(name);
    }

    /// <summary>
    /// When step: Pauses the stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to resume.</param>
    [When("the stopwatch '(.*)' is resumed")]
    public void Resume(string name)
    {
        stopwatchDriver.Resume(name);
    }

    /// <summary>
    /// Stores the elapsed time of the specified stopwatch in a variable for later use in the test.
    /// </summary>
    /// <param name="stopwatchName">The name of the stopwatch whose elapsed time is to be retrieved.</param>
    /// <param name="targetVariableName">The name of the variable in which to store the elapsed time.</param>
    [When("the elapsed time of stopwatch '(.*)' is stored in variable '(.*)'")]
    public void StoreElapsedInVariable(string stopwatchName, string targetVariableName)
    {
        stopwatchDriver.SaveInVariable(stopwatchName, targetVariableName);
    }
}