using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Driver for stopwatch interactions.
/// </summary>
public class StopwatchDriver(IStopwatchService stopwatchService, IVariableService variableService)
    : IStopwatchDriver
{
    /// <summary>
    /// Starts a new stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the new stopwatch.</param>
    public void StartNew(string name)
    {
        stopwatchService.StartNew(name);
    }

    /// <summary>
    /// Resumes a stopped stopwatch.
    /// </summary>
    /// <param name="name">Name of the stopwatch to resume.</param>
    public void Resume(string name)
    {
        stopwatchService.Resume(name);
    }

    /// <summary>
    /// Stops a running stopwatch.
    /// </summary>
    /// <param name="name">Name of the stopwatch to stop.</param>
    public void Stop(string name)
    {
        stopwatchService.Stop(name);
    }

    /// <summary>
    /// Stores the elapsed time (in seconds) of the specified stopwatch into a scenario variable.
    /// </summary>
    /// <param name="stopwatchName">Name of the stopwatch to get the elapsed time from.</param>
    /// <param name="targetVariableName">Name of the variable to store the elapsed time in.</param>
    public void SaveInVariable(string stopwatchName, string targetVariableName)
    {
        var elapsed = stopwatchService.GetElapsed(stopwatchName);
        variableService.SetVariable(targetVariableName, elapsed.ToString("F1"));

    }
}