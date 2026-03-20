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

    /// <summary>
    /// Writes a single line to the log output with parameter substitution.
    /// </summary>
    /// <param name="logMessage">The message to write.</param>
    /// <param name="messageParameters">Parameters to substitute.</param>
    void WriteLine(string logMessage, params object[] messageParameters);

    /// <summary>
    /// Logs a HttpResponse and its associated request in .http format.
    /// </summary>
    /// <param name="response"></param>
    Task LogResponse(HttpResponseMessage response);
}