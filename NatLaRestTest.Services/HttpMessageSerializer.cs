using NatLaRestTest.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace NatLaRestTest.Services;

/// <inheritdoc/>
public class HttpMessageSerializer(IContentStringBeautifier contentStringBeautifier) : IHttpMessageSerializer
{
    /// <inheritdoc/>
    public async Task<string> SerializeHttpResponseMessage(HttpResponseMessage response)
    {
        var sb = new StringBuilder();

        var request = response.RequestMessage;
        if (request is not null)
        {
            await LogRequest(sb, request);
        }

        sb.AppendLine();

        await LogResponse(response, sb);

        return sb.ToString();
    }

    private async Task LogRequest(StringBuilder sb, HttpRequestMessage request)
    {
        sb.AppendLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");
        AppendHttpMessageHeaders(sb, request.Headers, request.Content?.Headers);
        await AppendHttpMessageContent(sb, request.Content);
    }

    private async Task LogResponse(HttpResponseMessage response, StringBuilder sb)
    {
        sb.AppendLine($"HTTP/{response.Version} {(int)response.StatusCode} {response.ReasonPhrase}");
        AppendHttpMessageHeaders(sb, response.Headers, response.Content?.Headers);
        await AppendHttpMessageContent(sb, response.Content);
    }

    private async Task AppendHttpMessageContent(StringBuilder sb, HttpContent? httpMessageContent)
    {
        if (httpMessageContent is null) return;
        try
        {
            var contentString = PrepareContentStringForLogging(await httpMessageContent.ReadAsStringAsync(), httpMessageContent.Headers.ContentType?.MediaType);

            sb.AppendLine(contentString);
        }
        catch (ObjectDisposedException)
        {
            sb.AppendLine("<content stream already disposed>");
        }
    }

    private string PrepareContentStringForLogging(string contentString, string? contentType)
    {
        var formattedString = contentStringBeautifier.Beautify(contentString, contentType);
        return contentStringBeautifier.EnforceLength(formattedString);
    }

    private static void AppendHttpMessageHeaders(StringBuilder sb, HttpHeaders requestHeaders, HttpContentHeaders? contentHeaders)
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
}