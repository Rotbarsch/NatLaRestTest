using System.Threading.Tasks;

namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Defines high-level HTTP client operations and assertions used by logic components.
/// Provides methods to send requests, persist response data to variables, configure defaults, and assert outcomes.
/// </summary>
public interface IHttpClientLogic
{
    /// <summary>
    /// Sends an HTTP request with the specified method, path, optional body and content type.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">Relative path appended to the configured base URL.</param>
    /// <param name="requestBody">Optional request payload.</param>
    /// <param name="contentType">Request content type. Defaults to <c>application/json</c>.</param>
    Task SendRequest(string httpMethod, string relativePath, string? requestBody = null,
        string contentType = "application/json");

    /// <summary>
    /// Sends an HTTP request and uploads a file as the request body using stream/multipart content.
    /// </summary>
    /// <param name="httpMethod">HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">Absolute or relative URL.</param>
    /// <param name="fileName">Path to the file to upload.</param>
    /// <param name="contentType">Optional content type for the uploaded content.</param>
    Task SendRequestWithStreamBody(string httpMethod, string url, string fileName, string? contentType = null);

    /// <summary>
    /// Saves the current HTTP response content stream to a file.
    /// </summary>
    /// <param name="filePath">Destination file path.</param>
    Task SaveResponseStreamToFile(string filePath);

    /// <summary>
    /// Stores the length of the current HTTP response stream (in bytes) in a variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    Task StoreResponseStreamLengthInVariable(string variableName);

    /// <summary>
    /// Stores the current HTTP response body (as string) in a variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    Task StoreResponseBodyInVariable(string variableName);

    /// <summary>
    /// Stores the value of a response header in a variable.
    /// </summary>
    /// <param name="headerName">The response header name.</param>
    /// <param name="variableName">The target variable name.</param>
    void StoreResponseHeaderValueInVariable(string headerName, string variableName);

    /// <summary>
    /// Sets the base URL used for outgoing requests.
    /// </summary>
    /// <param name="baseUrl">Absolute base URL.</param>
    void SetBaseUrl(string baseUrl);

    /// <summary>
    /// Sets the default timeout for outgoing requests.
    /// </summary>
    /// <param name="seconds">Timeout in seconds.</param>
    void SetDefaultTimeout(int seconds);

    /// <summary>
    /// Adds a default header that will be included with each request.
    /// </summary>
    /// <param name="headerName">Header name.</param>
    /// <param name="headerValue">Header value.</param>
    void SetDefaultHeader(string headerName, string headerValue);

    /// <summary>
    /// Disables SSL certificate validation for outgoing requests.
    /// </summary>
    void DisableSslCertificateValidation();

    /// <summary>
    /// Asserts that the current HTTP response indicates success (status code 2xx).
    /// </summary>
    void ResponseIsSuccess();

    /// <summary>
    /// Asserts that the current HTTP response does not indicate success (non-2xx).
    /// </summary>
    void ResponseIsNotSuccess();

    /// <summary>
    /// Asserts that the current HTTP response status code equals the specified value.
    /// </summary>
    /// <param name="code">Expected HTTP status code.</param>
    void AssertResponseCode(int code);

    /// <summary>
    /// Asserts that the current HTTP response status code does not equal the specified value.
    /// </summary>
    /// <param name="code">HTTP status code.</param>
    void AssertResponseCodeIsNot(int code);

    /// <summary>
    /// Stores the response time (in milliseconds) of the current HTTP response in a variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    void StoreResponseTimeInVariable(string variableName);
}