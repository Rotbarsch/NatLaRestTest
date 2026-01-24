using Reqnroll;

namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
///     Declares step bindings related to sending HTTP requests via the shared HTTP client.
/// </summary>
public interface IHttpClientRequestBindings
{
    /// <summary>
    ///     When step: Sends an HTTP request with the specified method to the relative path without a request body.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., GET, POST, PUT, DELETE).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    [When("an? (GET|POST|PUT|DELETE|PATCH|HEAD|OPTIONS) request to '(.*)' is sent")]
    Task SendRequestWithoutBody(string httpMethod, string relativePath);

    /// <summary>
    ///     When step: Sends an HTTP request with the specified method and request body to the relative path. Uses the default
    ///     content type "application/json".
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a (POST|PUT|PATCH) request to '(.*)' with body is sent:")]
    Task SendRequestWithBodyWithoutContentType(string httpMethod, string relativePath, string requestBody);

    /// <summary>
    ///     When step: Sends an HTTP request with the specified method, content type, and request body to the relative path.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="relativePath">The relative path for the request.</param>
    /// <param name="contentType">The content type to set (e.g., "application/json").</param>
    /// <param name="requestBody">The raw request body payload.</param>
    [When("a (POST|PUT|PATCH) request to '(.*)' with content type '(.*)' and body is sent:")]
    Task SendRequestWithBodyWithContentType(string httpMethod, string relativePath, string contentType,
        string requestBody);
}