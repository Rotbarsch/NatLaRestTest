namespace NatLaRestTest.Services.Interfaces;

/// <summary>
///     Abstraction for writing log messages to test output.
/// </summary>
public interface ITestOutputLoggingService
{
    /// <summary>
    ///     Writes a single line to the log output.
    /// </summary>
    /// <param name="logMessage">The message to write.</param>
    void WriteLine(string logMessage);

    void WriteLine(string logMessage, params object[] messageParameters);
}