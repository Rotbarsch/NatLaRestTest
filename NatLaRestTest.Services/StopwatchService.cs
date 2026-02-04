using System.Diagnostics;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
/// Service for managing multiple stopwatches.
/// </summary>
public class StopwatchService : IStopwatchService
{
    private static readonly Dictionary<string, Stopwatch> Stopwatches = [];

    /// <summary>
    /// Starts a new stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to create.</param>
    public void StartNew(string name)
    {
        if (Stopwatches.ContainsKey(name))
        {
            Assert.Fail($"Stopwatch with name '{name}' is already running.");
        }

        Stopwatches.Add(name, Stopwatch.StartNew());
    }

    /// <summary>
    /// Stops a running stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to stop.</param>
    public void Stop(string name)
    {
        if (!Stopwatches.ContainsKey(name))
        {
            Assert.Fail($"Stopwatch with name '{name}' is not running.");
        }

        var sw = Stopwatches[name];
        if (!sw.IsRunning)
        {
            Assert.Fail($"Stopwatch with name '{name}' is not running.");
        }

        sw.Stop();
    }

    /// <summary>
    /// Resumes a stopped stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to resume.</param>
    public void Resume(string name)
    {
        if (!Stopwatches.ContainsKey(name))
        {
            Assert.Fail($"Stopwatch with name '{name}' is not running.");
        }

        var sw = Stopwatches[name];
        if (sw.IsRunning)
        {
            Assert.Fail($"Stopwatch with name '{name}' is already running.");
        }

        sw.Start();
    }

    /// <summary>
    /// Gets elapsed time in seconds for the specified stopwatch.
    /// </summary>
    /// <param name="name">The name of the stopwatch to retrieve elapsed time for.</param>
    /// <returns>The elapsed time in seconds.</returns>
    public double GetElapsed(string name)
    {
        if (!Stopwatches.ContainsKey(name))
        {
            Assert.Fail($"Stopwatch with name '{name}' does not exist.");
        }
        return Stopwatches[name].Elapsed.TotalSeconds;
    }
}