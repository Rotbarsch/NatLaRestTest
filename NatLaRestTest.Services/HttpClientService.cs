using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Provides a shared <see cref="HttpClient" /> and tracks the current <see cref="HttpResponseMessage" /> for a
///     scenario.
///     Supports configuring base address, default timeout, request headers and SSL certificate validation.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="HttpClientService" /> class.
/// </remarks>
/// <param name="loggingService">The logging Service used to write request/response traces.</param>
/// <param name="variableService">The variable Service used to manage variables.</param>
public class HttpClientService(ITestOutputLoggingService loggingService, IVariableService variableService) : IHttpClientService, IDisposable
{
    private readonly HttpClientOptions _httpClientOptions = new();
    private long? _responseTime;

    /// <summary>
    ///     Gets or sets the current HTTP response captured by the Service.
    /// </summary>
    public HttpResponseMessage? CurrentResponse { get; set; }

    /// <summary>
    ///     Releases resources held by the current response.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Sends an HTTP request with the specified method, relative path, optional request body and content type.
    ///     The request and response are written to the debug output for traceability.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">The relative URL path to request.</param>
    /// <param name="requestBody">Optional request payload as string.</param>
    /// <param name="contentType">The request content type. Defaults to <c>application/json</c>.</param>
    public async Task SendRequest(string httpMethod, string relativePath, string? requestBody = null,
        string contentType = "application/json")
    {
        CurrentResponse = null;
        _responseTime = null;

        var msg = new HttpRequestMessage(
            HttpMethod.Parse(httpMethod),
            relativePath);
        if (requestBody != null)
        {
            msg.Content = new StringContent(requestBody, new MediaTypeHeaderValue(contentType));
        }


        await LogHttpRequest(msg);
        using (var httpClient = GetConfiguredHttpClient())
        {
            var sw = Stopwatch.StartNew();
            CurrentResponse = await httpClient.SendAsync(msg);
            sw.Stop();
            loggingService.WriteLine($"Request took {sw.ElapsedMilliseconds} ms.");
            _responseTime = sw.ElapsedMilliseconds;
        }

        await LogHttpResponse(CurrentResponse);
    }

    /// <summary>
    ///     Sends an HTTP request with the specified method and uploads the contents of a file as multipart stream content.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">Path to the file to be uploaded.</param>
    /// <param name="contentType">Optional content type of the stream part.</param>
    public async Task SendRequestWithStreamBody(string httpMethod, string url, string fileName,
        string? contentType = null)
    {
        Assert.IsTrue(File.Exists(fileName), $"File '{fileName} does not exist.");

        await using var fileStream = File.OpenRead(fileName);
        var msg = new HttpRequestMessage(
            HttpMethod.Parse(httpMethod),
            url)
        {
            Content = new MultipartFormDataContent
            {
                new StreamContent(fileStream)
            }
        };

        await LogHttpRequest(msg);
        using (var httpClient = GetConfiguredHttpClient())
        {
            CurrentResponse = await httpClient.SendAsync(msg);
        }

        await LogHttpResponse(CurrentResponse);
    }

    /// <inheritdoc />
    public bool CurrentResponseIsSuccessful()
    {
        AssertResponseAvailable();
        return CurrentResponse!.IsSuccessStatusCode;
    }

    /// <inheritdoc />
    public int GetCurrentResponseStatusCode()
    {
        AssertResponseAvailable();
        return (int)CurrentResponse!.StatusCode;
    }

    /// <inheritdoc />
    public async Task<string> GetCurrentResponseAsString()
    {
        AssertResponseAvailable();
        return await CurrentResponse!.Content.ReadAsStringAsync();
    }

    /// <inheritdoc />
    public void SetBaseAddress(string baseUrl)
    {
        _httpClientOptions.BaseUrl = new(baseUrl);
    }

    /// <inheritdoc />
    public void SetDefaultTimeout(int seconds)
    {
        _httpClientOptions.DefaultTimeout = TimeSpan.FromSeconds(seconds);
    }

    /// <inheritdoc />
    public void SetDefaultHeader(string headerName, string headerValue)
    {
        _httpClientOptions.DefaultRequestHeaders.Add(headerName, headerValue);
    }

    /// <inheritdoc />
    public async Task SaveResponseStreamToFile(string filePath)
    {
        AssertResponseAvailable();
        var respStream = await CurrentResponse!.Content.ReadAsStreamAsync();

        // Ensure directory exists
        var dir = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Assert.Fail($"Path not found: {filePath}");
        }

        // Write stream to file
        await using var fileStream = File.Create(filePath);
        await respStream.CopyToAsync(fileStream);
        await fileStream.FlushAsync();
        loggingService.WriteLine($"Wrote '{fileStream.Length}' bytes to '{Path.GetFullPath(filePath)}'.");
    }

    /// <inheritdoc />
    public async Task<long> GetResponseStreamLength()
    {
        AssertResponseAvailable();
        return (await CurrentResponse!.Content.ReadAsStreamAsync()).Length;
    }

    /// <inheritdoc />
    public string GetCurrentResponseHeaderValue(string headerName)
    {
        AssertResponseAvailable();
        Assert.IsTrue(CurrentResponse!.Headers.TryGetValues(headerName, out var headerValues),
            $"No header with key '{headerName}' in current response.");
        return string.Join(",", headerValues!);
    }

    /// <inheritdoc />
    public void DisableSslCertificateValidation()
    {
        _httpClientOptions.CheckSsl = false;
    }

    /// <summary>
    /// Stores the response time (in milliseconds) of the current HTTP response into a scenario variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    public void StoreResponseTimeInVariable(string variableName)
    {
        Assert.NotNull(CurrentResponse);
        Assert.NotNull(_responseTime);
        variableService.SetVariable(variableName, _responseTime!.ToString());
    }

    protected virtual void Dispose(bool disposing)
    {
        CurrentResponse?.Dispose();
    }

    /// <summary>
    ///     Creates a configured <see cref="HttpClient" /> based on current options.
    /// </summary>
    /// <returns>A new configured <see cref="HttpClient" /> instance.</returns>
    private HttpClient GetConfiguredHttpClient()
    {
        HttpClient httpClient;
        if (_httpClientOptions.CheckSsl)
        {
            httpClient = new();
        }
        else
        {
            var httpClientHandler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
            };
            httpClient = new(httpClientHandler);
        }

        if (_httpClientOptions.BaseUrl is not null)
        {
            httpClient.BaseAddress = _httpClientOptions.BaseUrl;
        }

        if (_httpClientOptions.DefaultTimeout is not null)
        {
            httpClient.Timeout = _httpClientOptions.DefaultTimeout.Value;
        }

        foreach (var header in _httpClientOptions.DefaultRequestHeaders)
        {
            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return httpClient;
    }

    /// <summary>
    ///     Asserts that a current response is available.
    /// </summary>
    private void AssertResponseAvailable()
    {
        Assert.NotNull(CurrentResponse, "No current response available.");
    }

    /// <summary>
    ///     Logs details of the outgoing HTTP request.
    /// </summary>
    /// <param name="msg">The HTTP request message.</param>
    private async Task LogHttpRequest(HttpRequestMessage msg)
    {
        var bodyLength = 0;
        if (msg.Content != null)
        {
            var contentBytes = await msg.Content.ReadAsByteArrayAsync();
            bodyLength = contentBytes.Length;
        }

        var sb = new StringBuilder();

        sb.AppendLine($"Request to {msg.Method} {msg.RequestUri} with body size of {bodyLength} bytes with Headers:");
        foreach (var header in msg.Headers)
        {
            sb.AppendLine($"{header.Key} = {string.Join(",", header.Value)}");
        }

        loggingService.WriteLine(sb.ToString());
    }

    /// <summary>
    ///     Logs summary details of the received HTTP response.
    /// </summary>
    /// <param name="currentResponse">The HTTP response message.</param>
    private async Task LogHttpResponse(HttpResponseMessage currentResponse)
    {
        var bodyLength = (await currentResponse.Content.ReadAsByteArrayAsync()).Length;

        var sb = new StringBuilder();

        sb.AppendLine(
            $"Received response {currentResponse.StatusCode} with body size of {bodyLength} bytes with headers:");
        foreach (var header in currentResponse.Headers)
        {
            sb.AppendLine($"{header.Key} = {string.Join(",", header.Value)}");
        }

        if (!currentResponse.IsSuccessStatusCode)
        {
            sb.AppendLine(await currentResponse.Content.ReadAsStringAsync());
        }

        loggingService.WriteLine(sb.ToString());
    }

    /// <summary>
    ///     Options for configuring the internal <see cref="HttpClient" />.
    /// </summary>
    private record HttpClientOptions
    {
        /// <summary>Default timeout applied to requests.</summary>
        public TimeSpan? DefaultTimeout { get; set; }

        /// <summary>Base URL used as <see cref="HttpClient.BaseAddress" />.</summary>
        public Uri? BaseUrl { get; set; }

        /// <summary>Default request headers added to each request.</summary>
        public Dictionary<string, string> DefaultRequestHeaders { get; } = [];

        /// <summary>Whether to check SSL certificates. Set false to bypass validation.</summary>
        public bool CheckSsl { get; set; } = true;
    }
}