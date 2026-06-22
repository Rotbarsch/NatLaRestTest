using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Services.Helpers.OAuth;
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
/// <param name="natLaRestTestHttpClientFactory">Factory to create HttpClient instances.</param>
public class HttpClientService(ITestOutputLoggingService loggingService, IVariableService variableService, INatLaRestTestHttpClientFactory natLaRestTestHttpClientFactory) : IHttpClientService, IDisposable
{
    private readonly HttpClientOptions _httpClientOptions = new();
    private long? _responseTime;
    private bool _useNtlm;
    private OAuthHelper? _oAuthService;


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

        await SendHttpRequestMessage(msg);
    }

    /// <summary>
    ///    Sends an HTTP request with the specified method and uploads form content as key-value pairs in a dictionary.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="url"></param>
    /// <param name="dict">Content of the form.</param>
    /// <param name="contentType">Content-Type header, defaults to <c>multipart/form-data</c>.</param>
    public async Task SendFormRequest(string httpMethod, string url, Dictionary<string, string> dict, string contentType = "multipart/form-data")
    {
        using HttpContent formContent = new FormUrlEncodedContent(dict);
        var request = new HttpRequestMessage(new HttpMethod(httpMethod), url)
        {
            Content = formContent,
        };
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        await SendHttpRequestMessage(request);
    }

    /// <summary>
    ///     Sends an HTTP request with the specified method and uploads the contents of a file as multipart stream content.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">Path to the file to be uploaded.</param>
    /// <param name="contentType">Optional content type of the stream part.</param>
    /// <param name="formFieldName">Optional form field name for the file part. Defaults to <c>file</c>.</param>
    public async Task SendRequestWithStreamBody(string httpMethod, string url, string fileName,
        string? contentType = null, string formFieldName = "file")
    {
        Assert.IsTrue(File.Exists(fileName), $"File '{fileName} does not exist.");

        await using var fileStream = File.OpenRead(fileName);
        var streamContent = new StreamContent(fileStream);

        if (contentType is not null)
        {
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        }

        var formData = new MultipartFormDataContent();
        formData.Add(streamContent, formFieldName, Path.GetFileName(fileName));

        var msg = new HttpRequestMessage(
            HttpMethod.Parse(httpMethod),
            url)
        {
            Content = formData
        };

        await SendHttpRequestMessage(msg);
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
        _httpClientOptions.DefaultRequestHeaders.Remove(headerName);

        _httpClientOptions.DefaultRequestHeaders.Add(headerName, headerValue);
    }

    /// <inheritdoc />
    public void RemoveDefaultHeader(string headerName)
    {
        _httpClientOptions.DefaultRequestHeaders.Remove(headerName);
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
    public string GetCurrentResponseContentHeaderValue(string headerName)
    {
        AssertResponseAvailable();
        Assert.IsTrue(CurrentResponse!.Content.Headers.TryGetValues(headerName, out var headerValues),
            $"No content header with key '{headerName}' in current response.");
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

    [SupportedOSPlatform("windows")]
    public void EnableNtlm()
    {
        var name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        _useNtlm = true;
        loggingService.WriteLine($"Authenticating via NTLM as user '{name}'.");
    }

    public async Task EnableOAuth(OAuthOptions options)
    {
        _oAuthService = new OAuthHelper(options);
        await _oAuthService.GetOAuthToken();
    }

    protected virtual void Dispose(bool disposing)
    {
        CurrentResponse?.Dispose();
    }

    private async Task SendHttpRequestMessage(HttpRequestMessage msg)
    {
        if (_oAuthService is not null)
        {
            // Add Bearer token if OAuth is configured
            msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _oAuthService.GetOAuthToken());
        }

        using var httpClient = GetConfiguredHttpClient();
        var sw = Stopwatch.StartNew();
        CurrentResponse = await httpClient.SendAsync(msg);
        sw.Stop();
        loggingService.WriteLine($"Request took {sw.ElapsedMilliseconds} ms.");
        _responseTime = sw.ElapsedMilliseconds;

        await loggingService.LogResponse(CurrentResponse);
    }

    /// <summary>
    ///     Creates a configured <see cref="HttpClient" /> based on current options.
    /// </summary>
    /// <returns>A new configured <see cref="HttpClient" /> instance.</returns>
    private HttpClient GetConfiguredHttpClient()
    {
        HttpClientHandler httpClientHandler;

        //HttpClient httpClient;
        if (_httpClientOptions.CheckSsl)
        {
            httpClientHandler = new HttpClientHandler()
            {
                UseDefaultCredentials = _useNtlm,
            };
        }
        else
        {
            httpClientHandler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                UseDefaultCredentials = _useNtlm,
            };
        }

        var httpClient = natLaRestTestHttpClientFactory.CreateHttpClient(httpClientHandler);

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