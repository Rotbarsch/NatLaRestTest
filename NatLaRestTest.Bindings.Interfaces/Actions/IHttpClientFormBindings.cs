using Reqnroll;

namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Step bindings for sending HTTP requests with form content specified as key-value pairs in a data table.
/// </summary>
public interface IHttpClientFormBindings
{
    /// <summary>
    ///    When step: Sends an HTTP request with form content specified as key-value pairs in a data table.
    ///     Example:
    ///     | Key   | Value   |
    ///     | Name  | John    |
    ///     | Age   | 30      |
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="formContent">The form content as key-value pairs.</param>
    [When("^a '([^']*)' request is made to '([^']*)' with the following form content:$")]
    Task SendFormRequest(string httpMethod, string url, DataTable formContent);

    /// <summary>
    ///    When step: Sends an HTTP POST request with form content specified as key-value pairs in a data table.
    ///     Example:
    ///     | Key   | Value   |
    ///     | Name  | John    |
    ///     | Age   | 30      |
    /// </summary>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="formContent">The form content as key-value pairs.</param>
    [When("^a request is made to '([^']*)' with the following form content:$")]
    Task SendFormRequest(string url, DataTable formContent);

    /// <summary>
    ///    When step: Sends an HTTP request with form content specified as key-value pairs in a data table.
    ///     Example:
    ///     | Key   | Value   |
    ///     | Name  | John    |
    ///     | Age   | 30      |
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="contentType">The content type of the form data.</param>
    /// <param name="formContent">The form content as key-value pairs.</param>
    [When("^a '([^']*)' request is made to '([^']*)' with content type '(.*)' and the following form content:$")]
    Task SendFormRequestWithContentType(string httpMethod, string url, string contentType, DataTable formContent);

    /// <summary>
    ///    When step: Sends an HTTP POST request with form content specified as key-value pairs in a data table.
    ///     Example:
    ///     | Key   | Value   |
    ///     | Name  | John    |
    ///     | Age   | 30      |
    /// </summary>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="contentType">The content type of the form data.</param>
    /// <param name="formContent">The form content as key-value pairs.</param>
    [When("^a request is made to '([^']*)' with content type '(.*)' and the following form content:$")]
    Task SendFormRequestWithContentType(string url, string contentType, DataTable formContent);
}