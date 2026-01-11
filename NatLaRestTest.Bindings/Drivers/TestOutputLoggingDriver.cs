using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Drivers;

/// <summary>
/// Driver that writes log messages to the test output helper.
/// </summary>
public class TestOutputLoggingDriver:ITestOutputLoggingDriver
{
    private readonly IReqnrollOutputHelper _outputHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestOutputLoggingDriver"/> class.
    /// </summary>
    /// <param name="outputHelper">The Reqnroll output helper to write logs to.</param>
    public TestOutputLoggingDriver(IReqnrollOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    /// <inheritdoc />
    public void WriteLine(string logMessage)
    {
        _outputHelper.WriteLine(logMessage);
    }
}