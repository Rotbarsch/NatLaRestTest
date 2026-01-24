namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Service for managing multiple stopwatches.
/// </summary>
public interface IStopwatchService
{
    /// <summary>
    /// Starts a new stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to create.</param>
    void StartNew(string name);

    /// <summary>
    /// Stops a running stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to stop.</param>
    void Stop(string name);

    /// <summary>
    /// Resumes a stopped stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to resume.</param>
    void Resume(string name);

    /// <summary>
    /// Gets elapsed time in seconds for the specified stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to retrieve elapsed time for.</param>
    /// <returns>The elapsed time in seconds.</returns>
    double GetElapsed(string name);
}