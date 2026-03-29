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
/// <param name="httpMessageSerializer">Service to serialize HTTP messages.</param>
public partial class TestOutputLoggingService(IReqnrollOutputHelper outputHelper, IHttpMessageSerializer httpMessageSerializer) : ITestOutputLoggingService
{
    /// <inheritdoc />
    public void WriteLine(string logMessage)
    {
        outputHelper.WriteLine("[NatLaRestTest]" + logMessage);
    }

    public void WriteLine(string logMessage, params object[] messageParameters)
    {
        int i = 0;
        var numeric = VariableRegEx().Replace(logMessage, _ => $"{{{i++}}}");
        var result = string.Format(numeric, messageParameters.ToArray());

        WriteLine(result);
    }

    public async Task LogResponse(HttpResponseMessage response)
    {
        var serialized = await httpMessageSerializer.SerializeHttpResponseMessage(response);
        outputHelper.WriteLine(serialized);
    }

    [GeneratedRegex(@"{[^}]+}")]
    private static partial Regex VariableRegEx();
}