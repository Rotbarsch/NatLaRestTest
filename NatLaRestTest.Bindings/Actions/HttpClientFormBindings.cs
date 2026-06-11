using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings for sending HTTP requests with form content specified as key-value pairs in a data table.
/// </summary>
/// <param name="httpClientDriver">Instance of <see cref="IHttpClientDriver"/> to use.</param>
[Binding]
public class HttpClientFormBindings(IHttpClientDriver httpClientDriver) : IHttpClientFormBindings
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
    public async Task SendFormRequest(string httpMethod, string url, DataTable formContent)
    {
        await httpClientDriver.SendFormRequest(httpMethod, url, GetFormDict(formContent));
    }

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
    public async Task SendFormRequest(string url, DataTable formContent)
    {
        await SendFormRequest("POST", url, formContent);
    }

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
    public async Task SendFormRequestWithContentType(string httpMethod, string url, string contentType, DataTable formContent)
    {
        await httpClientDriver.SendFormRequest(httpMethod, url, GetFormDict(formContent),contentType);
    }

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
    public async Task SendFormRequestWithContentType(string url, string contentType, DataTable formContent)
    {
        await httpClientDriver.SendFormRequest("POST", url, GetFormDict(formContent), contentType);
    }

    private Dictionary<string, string> GetFormDict(DataTable formContent)
    {
        return formContent.Rows.ToDictionary(x => x["Key"], x => x["Value"]);
    }
}