using System.Text.RegularExpressions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that writes log messages to the test output helper.
/// </summary>
public class TestOutputLoggingService : ITestOutputLoggingService
{
    private readonly IReqnrollOutputHelper _outputHelper;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TestOutputLoggingService" /> class.
    /// </summary>
    /// <param name="outputHelper">The Reqnroll output helper to write logs to.</param>
    public TestOutputLoggingService(IReqnrollOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    /// <inheritdoc />
    public void WriteLine(string logMessage)
    {
        _outputHelper.WriteLine("[NatLaRestTest]" + logMessage);
    }

    public void WriteLine(string logMessage, params object[] messageParameters)
    {
        var updatedParamArray = new List<object?>();

        foreach (var mp in messageParameters)
        {
            var s = mp?.ToString();
            if (string.IsNullOrEmpty(s))
            {
                updatedParamArray.Add(s);
                continue;
            }

            if (s.Length > 50)
            {
                updatedParamArray.Add(s.Substring(0, 50) + "...");
                continue;
            }

            updatedParamArray.Add(s);
        }

        int i = 0;
        var numeric = Regex.Replace(logMessage, @"{[^}]+}", _ => $"{{{i++}}}");
        var result = string.Format(numeric, updatedParamArray.ToArray());

        WriteLine(result);
    }
}