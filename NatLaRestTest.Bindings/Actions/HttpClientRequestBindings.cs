using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for issuing HTTP requests with the shared HTTP client (GET and generic verbs, with/without body).
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="HttpClientRequestBindings" /> class.
/// </remarks>
/// <param name="httpClientDriver">Driver component used to send HTTP requests.</param>
[Binding]
public class HttpClientRequestBindings(IHttpClientDriver httpClientDriver) : IHttpClientRequestBindings
{

    /// <summary>
    ///     When step: Sends an HTTP request with the specified method to the relative path without a request body.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    [When("a '(.*)' request to '(.*)' is made")]
    public async Task SendRequestWithoutBody(string httpMethod, string relativePath) =>
        await httpClientDriver.SendRequest(httpMethod, relativePath);

    /// <summary>
    ///     When step: Sends an HTTP request with the specified method and request body to the relative path. Uses the default
    ///     content type "application/json".
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a '(.*)' request to '(.*)' is made with the following request body:")]
    public async Task SendRequestWithBodyWithoutContentType(string httpMethod, string relativePath, string requestBody) =>
        await httpClientDriver.SendRequest(httpMethod, relativePath, requestBody);

    /// <summary>
    ///     When step: Sends an HTTP request with the specified method, content type, and request body to the relative path.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="contentType">The content type to set (e.g., "application/json").</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a '(.*)' request to '(.*)' is made with content type '(.*)' and the following request body:")]
    public async Task SendRequestWithBodyWithContentType(string httpMethod, string relativePath, string contentType,
        string requestBody) =>
        await httpClientDriver.SendRequest(httpMethod, relativePath, requestBody, contentType);
}