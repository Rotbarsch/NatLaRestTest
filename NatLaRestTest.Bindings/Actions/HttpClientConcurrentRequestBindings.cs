using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Sends multiple HTTP requests concurrently and stores each response independently.
/// </summary>
[Binding]
public sealed class HttpClientConcurrentRequestBindings(
    IHttpClientDriver httpClientDriver,
    IVariableService variableService)
{
    /// <summary>
    /// Sends one request per table row. Required columns are HTTP method, Request URL, Body,
    /// Response code variable, and Response body variable. The optional Headers column accepts
    /// semicolon-separated key=value pairs; quote values containing semicolons. Row headers
    /// override configured default headers. Non-empty bodies default to application/json.
    /// </summary>
    /// <example>
    /// <code>
    /// When the following HTTP requests are sent concurrently:
    ///     | HTTP method | Request URL | Body           | Headers                                 | Response code variable | Response body variable |
    ///     | GET         | /items      |                | Accept=application/json; X-Client=NatLa  | listCode               | listBody               |
    ///     | POST        | /items      | {"name":"new"} |                                         | createCode             | createBody             |
    ///     | POST        | /upload     | text           | Content-Type="text/plain; charset=utf-8" | uploadCode             | uploadBody             |
    /// Then the value of variable 'listCode' equals '200'
    /// </code>
    /// </example>
    /// <param name="requests">A table containing the requests to send concurrently.</param>
    [When("the following HTTP requests are sent concurrently:")]
    public async Task SendRequestsConcurrently(DataTable requests)
    {
        var methodColumn = GetColumnName(requests, "HTTP method");
        var urlColumn = GetColumnName(requests, "Request URL");
        var bodyColumn = GetColumnName(requests, "Body");
        var responseCodeVariableColumn = GetColumnName(requests, "Response code variable");
        var responseBodyVariableColumn = GetColumnName(requests, "Response body variable");
        var headersColumn = FindColumnName(requests, "Headers");

        if (requests.Rows.Count == 0)
        {
            throw new ArgumentException("At least one request row is required.", nameof(requests));
        }

        var entries = requests.Rows.Select(row => new RequestEntry(
            Resolve(row[methodColumn]),
            Resolve(row[urlColumn]),
            Resolve(row[bodyColumn]),
            headersColumn is null ? [] : ParseHeaders(Resolve(row[headersColumn])),
            Resolve(row[responseCodeVariableColumn]),
            Resolve(row[responseBodyVariableColumn]))).ToArray();

        ValidateResponseVariableNames(entries);

        var results = await Task.WhenAll(entries.Select(SendRequestAsync));
        foreach (var result in results)
        {
            variableService.SetVariable(result.ResponseCodeVariable, result.ResponseCode);
            variableService.SetVariable(result.ResponseBodyVariable, result.ResponseBody);
        }
    }

    private async Task<RequestResult> SendRequestAsync(RequestEntry entry)
    {
        using var request = new HttpRequestMessage(new HttpMethod(entry.Method), entry.Url);
        if (entry.Body.Length > 0)
        {
            request.Content = new StringContent(entry.Body, Encoding.UTF8, "application/json");
        }

        foreach (var header in entry.Headers)
        {
            AddHeader(request, header.Key, header.Value);
        }

        using var response = await httpClientDriver.SendIndependentRequest(request);
        var responseBody = await response.Content.ReadAsStringAsync();
        return new RequestResult(
            entry.ResponseCodeVariable,
            entry.ResponseBodyVariable,
            ((int)response.StatusCode).ToString(CultureInfo.InvariantCulture),
            responseBody);
    }

    private string Resolve(string value)
    {
        return variableService.ResolvePlaceHolderString(value)
               ?? throw new InvalidOperationException($"Could not resolve value '{value}'.");
    }

    private static string GetColumnName(DataTable table, string requiredName)
    {
        return FindColumnName(table, requiredName)
               ?? throw new ArgumentException($"The request table must include a '{requiredName}' column.");
    }

    private static string? FindColumnName(DataTable table, string name)
    {
        return table.Header.FirstOrDefault(header =>
            string.Equals(header, name, StringComparison.OrdinalIgnoreCase));
    }

    private static Dictionary<string, string> ParseHeaders(string headerValue)
    {
        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var entry in SplitHeaderEntries(headerValue))
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                continue;
            }

            var separator = entry.IndexOf('=');
            if (separator <= 0)
            {
                throw new FormatException($"Header entry '{entry}' must use the key=value format.");
            }

            var name = entry[..separator].Trim();
            var value = Unquote(entry[(separator + 1)..].Trim());
            if (name.Length == 0)
            {
                throw new FormatException($"Header entry '{entry}' has an empty name.");
            }

            headers[name] = value;
        }

        return headers;
    }

    private static IEnumerable<string> SplitHeaderEntries(string value)
    {
        var start = 0;
        var inQuotes = false;
        var escaped = false;

        for (var index = 0; index < value.Length; index++)
        {
            var character = value[index];
            if (character == '"' && !escaped)
            {
                inQuotes = !inQuotes;
            }
            else if (character == ';' && !inQuotes)
            {
                yield return value[start..index].Trim();
                start = index + 1;
            }

            if (character == '\\' && inQuotes && !escaped)
            {
                escaped = true;
            }
            else
            {
                escaped = false;
            }
        }

        if (inQuotes)
        {
            throw new FormatException("Header values must not contain an unmatched quote.");
        }

        yield return value[start..].Trim();
    }

    private static string Unquote(string value)
    {
        if (value.Length < 2 || value[0] != '"' || value[^1] != '"')
        {
            return value;
        }

        return value[1..^1].Replace("\\\"", "\"").Replace("\\\\", "\\");
    }

    private static void AddHeader(HttpRequestMessage request, string name, string value)
    {
        if (string.Equals(name, "Content-Type", StringComparison.OrdinalIgnoreCase))
        {
            request.Content ??= new ByteArrayContent(Array.Empty<byte>());
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(value);
            return;
        }

        if (string.Equals(name, "Host", StringComparison.OrdinalIgnoreCase))
        {
            request.Headers.Host = value;
            return;
        }

        if (request.Headers.TryAddWithoutValidation(name, value))
        {
            return;
        }

        request.Content ??= new ByteArrayContent(Array.Empty<byte>());
        if (!request.Content.Headers.TryAddWithoutValidation(name, value))
        {
            throw new FormatException($"'{name}' is not a valid request or content header.");
        }
    }

    private static void ValidateResponseVariableNames(IEnumerable<RequestEntry> entries)
    {
        var variableNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var entry in entries)
        {
            if (string.IsNullOrWhiteSpace(entry.ResponseCodeVariable) ||
                string.IsNullOrWhiteSpace(entry.ResponseBodyVariable))
            {
                throw new ArgumentException("Response variable names cannot be empty.");
            }

            if (!variableNames.Add(entry.ResponseCodeVariable) ||
                !variableNames.Add(entry.ResponseBodyVariable))
            {
                throw new ArgumentException("Each response code and body must use a unique variable name.");
            }
        }
    }

    private sealed record RequestEntry(
        string Method,
        string Url,
        string Body,
        Dictionary<string, string> Headers,
        string ResponseCodeVariable,
        string ResponseBodyVariable);

    private sealed record RequestResult(
        string ResponseCodeVariable,
        string ResponseBodyVariable,
        string ResponseCode,
        string ResponseBody);
}
