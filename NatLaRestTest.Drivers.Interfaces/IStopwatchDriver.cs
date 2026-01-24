namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Driver for stopwatch interactions.
/// </summary>
public interface IStopwatchDriver
{
    /// <summary>
    /// Starts a new stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the new stopwatch.</param>
    void StartNew(string name);

    /// <summary>
    /// Resumes a stopped stopwatch.
    /// </summary>
    /// <param name="name">Name of the stopwatch to resume.</param>
    void Resume(string name);

    /// <summary>
    /// Stops a running stopwatch.
    /// </summary>
    /// <param name="name">Name of the stopwatch to stop.</param>
    void Stop(string name);

    /// <summary>
    /// Stores the elapsed time (in seconds) of the specified stopwatch into a scenario variable.
    /// </summary>
    /// <param name="stopwatchName">Name of the stopwatch to get the elapsed time from.</param>
    /// <param name="targetVariableName">Name of the variable to store the elapsed time in.</param>
    void SaveInVariable(string stopwatchName, string targetVariableName);
}