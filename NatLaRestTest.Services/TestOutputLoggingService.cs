using System.Collections.Generic;
using System.Text.RegularExpressions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that writes log messages to the test output helper.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="TestOutputLoggingService" /> class.
/// </remarks>
/// <param name="outputHelper">The Reqnroll output helper to write logs to.</param>
public partial class TestOutputLoggingService(IReqnrollOutputHelper outputHelper) : ITestOutputLoggingService
{

    /// <inheritdoc />
    public void WriteLine(string logMessage)
    {
        outputHelper.WriteLine("[NatLaRestTest]" + logMessage);
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
                updatedParamArray.Add(s[..50] + "...");
                continue;
            }

            updatedParamArray.Add(s);
        }

        int i = 0;
        var numeric = VariableRegEx().Replace(logMessage, _ => $"{{{i++}}}");
#pragma warning disable IDE0305 // Simplify collection initialization
        var result = string.Format(numeric, updatedParamArray.ToArray());
#pragma warning restore IDE0305 // Simplify collection initialization

        WriteLine(result);
    }

    [GeneratedRegex(@"{[^}]+}")]
    private static partial Regex VariableRegEx();
}