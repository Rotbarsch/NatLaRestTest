using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for issuing HTTP requests with the shared HTTP client (GET and generic verbs, with/without body).
/// </summary>
[Binding]
public class HttpClientRequestBindings
{
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestBindings"/> class.
    /// </summary>
    /// <param name="httpClientDriver">The HTTP client driver dependency.</param>
    public HttpClientRequestBindings(IHttpClientDriver httpClientDriver)
    {
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    /// When step: Sends an HTTP GET request to the specified relative path using the shared HTTP client.
    /// </summary>
    /// <param name="relativePath">The relative path for the request (e.g., "products/1").</param>
    [When("a request to '(.*)' is made")]
    public async Task GetRequest(string relativePath)
    {
        await _httpClientDriver.SendRequest(HttpMethod.Get.Method, relativePath);
    }

    /// <summary>
    /// When step: Sends an HTTP request with the specified method to the relative path without a request body.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    [When("a '(.*)' request to '(.*)' is made")]
    public async Task SendRequestWithoutBody(string httpMethod, string relativePath)
    {
        await _httpClientDriver.SendRequest(httpMethod, relativePath);
    }

    /// <summary>
    /// When step: Sends an HTTP request with the specified method and request body to the relative path. Uses the default content type "application/json".
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a '(.*)' request to '(.*)' is made with the following request body:")]
    public async Task SendRequestWithBodyWithoutContentType(string httpMethod, string relativePath, string requestBody)
    {
        await _httpClientDriver.SendRequest(httpMethod, relativePath, requestBody);
    }

    /// <summary>
    /// When step: Sends an HTTP request with the specified method, content type, and request body to the relative path.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="contentType">The content type to set (e.g., "application/json").</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a '(.*)' request to '(.*)' is made with content type '(.*)' and the following request body:")]
    public async Task SendRequestWithBodyWithContentType(string httpMethod, string relativePath, string contentType, string requestBody)
    {
        await _httpClientDriver.SendRequest(httpMethod, relativePath, requestBody, contentType);
    }
}