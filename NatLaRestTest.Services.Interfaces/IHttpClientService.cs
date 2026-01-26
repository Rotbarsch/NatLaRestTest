using System.Threading.Tasks;
using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Services.Interfaces;

/// <summary>
///     Abstraction over HTTP request/response handling for tests, providing methods to send requests,
///     access the current response, configure client defaults, and work with response content and headers.
/// </summary>
public interface IHttpClientService
{
    /// <summary>
    ///     Sends an HTTP request with the specified method, relative path, optional request body and content type.
    ///     The request and response are written to the debug output for traceability.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">The relative URL path to request.</param>
    /// <param name="requestBody">Optional request payload as string.</param>
    /// <param name="contentType">The request content type. Defaults to <c>application/json</c>.</param>
    Task SendRequest(string httpMethod, string relativePath, string? requestBody = null,
        string contentType = "application/json");

    /// <summary>
    ///     Sends an HTTP request with the specified method and uploads the contents of a file as stream content.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">Path to the file to be uploaded.</param>
    /// <param name="contentType">Optional content type of the stream part.</param>
    Task SendRequestWithStreamBody(string httpMethod, string url, string fileName, string? contentType = null);

    /// <summary>
    ///     Determines whether the last HTTP response indicates success.
    /// </summary>
    /// <returns><c>true</c> if the response status code is in the 2xx range; otherwise, <c>false</c>.</returns>
    bool CurrentResponseIsSuccessful();

    /// <summary>
    ///     Gets the status code of the last HTTP response.
    /// </summary>
    /// <returns>The numeric HTTP status code.</returns>
    int GetCurrentResponseStatusCode();

    /// <summary>
    ///     Reads the content of the last HTTP response as a string.
    /// </summary>
    /// <returns>A task that resolves to the response body as string.</returns>
    Task<string> GetCurrentResponseAsString();

    /// <summary>
    ///     Sets the base address for outgoing HTTP requests.
    /// </summary>
    /// <param name="baseUrl">The absolute base URL.</param>
    void SetBaseAddress(string baseUrl);

    /// <summary>
    ///     Sets the default timeout applied to HTTP requests.
    /// </summary>
    /// <param name="seconds">Timeout in seconds.</param>
    void SetDefaultTimeout(int seconds);

    /// <summary>
    ///     Adds a default header to all outgoing HTTP requests.
    /// </summary>
    /// <param name="headerName">The header name.</param>
    /// <param name="headerValue">The header value.</param>
    void SetDefaultHeader(string headerName, string headerValue);

    /// <summary>
    ///     Saves the response content stream to a file.
    /// </summary>
    /// <param name="filePath">Target file path.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task SaveResponseStreamToFile(string filePath);

    /// <summary>
    ///     Gets the length of the response content stream in bytes.
    /// </summary>
    /// <returns>A task that resolves to the stream length in bytes.</returns>
    Task<long> GetResponseStreamLength();

    /// <summary>
    ///     Gets the value of a header from the last HTTP response.
    /// </summary>
    /// <param name="headerName">The response header name.</param>
    /// <returns>The header value concatenated if multiple values exist.</returns>
    string GetCurrentResponseHeaderValue(string headerName);

    /// <summary>
    ///     Disables SSL certificate validation for outgoing requests.
    /// </summary>
    void DisableSslCertificateValidation();

    /// <summary>
    /// Stores response time in milliseconds in a variable.
    /// </summary>
    /// <param name="variableName">Target variable name.</param>
    void StoreResponseTimeInVariable(string variableName);

    /// <summary>
    /// Enables NTLM authentication.
    /// </summary>
    void EnableNtlm();

    /// <summary>
    /// Enables OAuth authentication.
    /// </summary>
    /// <param name="options">OAuth configuration.</param>
    Task EnableOAuth(OAuthOptions options);
}