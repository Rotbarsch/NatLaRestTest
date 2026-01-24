namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Step bindings for Stopwatch setup.
/// </summary>
public interface IStopwatchBindings
{
    /// <summary>
    /// When step: Creates and starts a new stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to create.</param>
    void Start(string name);

    /// <summary>
    /// When step: Stops the stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to stop.</param>
    void Stop(string name);

    /// <summary>
    /// When step: Pauses the stopwatch with the specified name.
    /// </summary>
    /// <param name="name">Name of the stopwatch to resume.</param>
    void Resume(string name);

    /// <summary>
    /// Stores the elapsed time of the specified stopwatch in a variable for later use in the test.
    /// </summary>
    /// <param name="stopwatchName">The name of the stopwatch whose elapsed time is to be retrieved.</param>
    /// <param name="targetVariableName">The name of the variable in which to store the elapsed time.</param>
    void StoreElapsedInVariable(string stopwatchName, string targetVariableName);
}