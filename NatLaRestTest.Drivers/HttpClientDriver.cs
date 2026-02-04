using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides high-level HTTP operations using an underlying Service and stores results in scenario variables.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="HttpClientDriver"/> class.
/// </remarks>
/// <param name="httpClientService">Service used to send HTTP requests and access responses.</param>
/// <param name="variableService">Service used to store values in scenario variables.</param>
public class HttpClientDriver(IHttpClientService httpClientService, IVariableService variableService) : IHttpClientDriver
{

    /// <summary>
    /// Sends an HTTP request with optional body and content type.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">Relative URL path to request.</param>
    /// <param name="requestBody">Optional request body as string.</param>
    /// <param name="contentType">Content type of the request body. Defaults to application/json.</param>
    public async Task SendRequest(string httpMethod, string relativePath, string? requestBody = null,
        string contentType = "application/json")
    {
        await httpClientService.SendRequest(httpMethod, relativePath, requestBody, contentType);
    }

    /// <summary>
    /// Sends an HTTP request and uploads the contents of a file as multipart form data.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">Absolute or relative URL.</param>
    /// <param name="fileName">Path to the file to upload.</param>
    /// <param name="contentType">Optional content type of the stream part.</param>
    public async Task SendRequestWithStreamBody(string httpMethod, string url, string fileName,
        string? contentType = null)
    {
        await httpClientService.SendRequestWithStreamBody(httpMethod, url, fileName, contentType);
    }

    /// <summary>
    /// Saves the current response stream to a file.
    /// </summary>
    /// <param name="filePath">Path to the destination file.</param>
    public async Task SaveResponseStreamToFile(string filePath)
    {
        await httpClientService.SaveResponseStreamToFile(filePath);
    }

    /// <summary>
    /// Retrieves the current response stream length and stores it in a scenario variable.
    /// </summary>
    /// <param name="variableName">Name of the scenario variable to store the length value.</param>
    public async Task StoreResponseStreamLengthInVariable(string variableName)
    {
        var length = await httpClientService.GetResponseStreamLength();
        variableService.SetVariable(variableName, length.ToString());
    }

    /// <summary>
    /// Retrieves the current response body and stores it in a scenario variable.
    /// </summary>
    /// <param name="variableName">Name of the scenario variable to store the body.</param>
    public async Task StoreResponseBodyInVariable(string variableName)
    {
        variableService.SetVariable(variableName, await httpClientService.GetCurrentResponseAsString());
    }

    /// <summary>
    /// Retrieves a header value from the current response and stores it in a scenario variable.
    /// </summary>
    /// <param name="headerName">Name of the header.</param>
    /// <param name="variableName">Name of the scenario variable to store the value.</param>
    public void StoreResponseHeaderValueInVariable(string headerName, string variableName)
    {
        var headerValue = httpClientService.GetCurrentResponseHeaderValue(headerName);
        variableService.SetVariable(variableName, headerValue);
    }

    /// <summary>
    /// Sets the base URL used by the HTTP client.
    /// </summary>
    /// <param name="baseUrl">Base URL.</param>
    public void SetBaseUrl(string baseUrl)
    {
        httpClientService.SetBaseAddress(baseUrl);
    }

    /// <summary>
    /// Sets the default timeout used by the HTTP client.
    /// </summary>
    /// <param name="seconds">Timeout in seconds.</param>
    public void SetDefaultTimeout(int seconds)
    {
        httpClientService.SetDefaultTimeout(seconds);
    }

    /// <summary>
    /// Adds a default header to all outgoing requests.
    /// </summary>
    /// <param name="headerName">Header name.</param>
    /// <param name="headerValue">Header value.</param>
    public void SetDefaultHeader(string headerName, string headerValue)
    {
        httpClientService.SetDefaultHeader(headerName, headerValue);
    }

    /// <summary>
    /// Disables SSL certificate validation on the HTTP client.
    /// </summary>
    public void DisableSslCertificateValidation()
    {
        httpClientService.DisableSslCertificateValidation();
    }

    /// <summary>
    /// Asserts that the current response indicates success (HTTP 2xx).
    /// </summary>
    public void ResponseIsSuccess()
    {
        Assert.IsTrue(httpClientService.CurrentResponseIsSuccessful(),
            $"Response status code {httpClientService.GetCurrentResponseStatusCode()} does not indicate success.");
    }

    /// <summary>
    /// Asserts that the current response does not indicate success.
    /// </summary>
    public void ResponseIsNotSuccess()
    {
        Assert.IsFalse(httpClientService.CurrentResponseIsSuccessful(),
            $"Response status code {httpClientService.GetCurrentResponseStatusCode()} does indicate success.");
    }

    /// <summary>
    /// Asserts that the current response status code equals the expected value.
    /// </summary>
    /// <param name="code">Expected HTTP status code (e.g., 200).</param>
    public void AssertResponseCode(int code)
    {
        Assert.AreEqual(code, httpClientService.GetCurrentResponseStatusCode(),
            $"Expected response code {code} but got {httpClientService.GetCurrentResponseStatusCode()}");
    }

    /// <summary>
    /// Asserts that the current response status code does not equal the specified value.
    /// </summary>
    /// <param name="code">HTTP status code that must not match.</param>
    public void AssertResponseCodeIsNot(int code)
    {
        Assert.AreNotEqual(code, httpClientService.GetCurrentResponseStatusCode(),
            $"Expected response code to not be equal {code}.");
    }

    /// <summary>
    /// Stores the response time (in milliseconds) of the current HTTP response into a variable.
    /// </summary>
    /// <param name="variableName"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StoreResponseTimeInVariable(string variableName)
    {
        httpClientService.StoreResponseTimeInVariable(variableName);
    }

    /// <summary>
    /// Enables NTLM authentication for outgoing requests, using the executing user as credential.
    /// </summary>
    public void EnableNtlmAuthentication()
    {
        httpClientService.EnableNtlm();
    }

    /// <summary>
    /// Enables OAuth authentication for outgoing requests, using the provided options.
    /// </summary>
    /// <param name="options">OAuth configuration.</param>
    public async Task EnableOAuth(OAuthOptions options)
    {
        await httpClientService.EnableOAuth(options);
    }
}