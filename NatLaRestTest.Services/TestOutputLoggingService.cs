using System.Net.Http.Headers;
using System.Text;
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

    public async Task LogResponse(HttpResponseMessage response)
    {
        var sb = new StringBuilder();

        var request = response.RequestMessage;
        if (request is not null)
        {
            await LogRequest(sb, request);
        }

        sb.AppendLine();

        await LogResponse(response, sb);

        outputHelper.WriteLine(sb.ToString());

    }

    private async Task LogRequest(StringBuilder sb, HttpRequestMessage request)
    {
        sb.AppendLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");
        AppendHttpMessageHeaders(sb,request.Headers, request.Content?.Headers);
        await AppendHttpMessageContent(sb, request.Content);
    }

    private async Task LogResponse(HttpResponseMessage response, StringBuilder sb)
    {
        sb.AppendLine($"HTTP/{response.Version} {(int)response.StatusCode} {response.ReasonPhrase}");
        AppendHttpMessageHeaders(sb,response.Headers,response.Content?.Headers);
        await AppendHttpMessageContent(sb, response.Content);
    }

    private async Task AppendHttpMessageContent(StringBuilder sb, HttpContent? httpMessageContent)
    {
        if (httpMessageContent is null) return;
        try
        {
            var contentString = await httpMessageContent.ReadAsStringAsync();
            sb.AppendLine(contentString);
        }
        catch (ObjectDisposedException)
        {
            sb.AppendLine("<content stream already disposed>");
        }
    }

    private void AppendHttpMessageHeaders(StringBuilder sb, HttpHeaders requestHeaders, HttpContentHeaders? contentHeaders)
    {
        foreach (var h in requestHeaders)
        {
            sb.AppendLine($"{h.Key}: {string.Join(", ", h.Value)}");
        }

        if (contentHeaders is not null)
        {
            foreach (var h in contentHeaders)
            {
                sb.AppendLine($"{h.Key}: {string.Join(", ", h.Value)}");
            }
        }
    }

    [GeneratedRegex(@"{[^}]+}")]
    private static partial Regex VariableRegEx();
}