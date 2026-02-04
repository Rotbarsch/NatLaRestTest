using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for uploading files as stream content in HTTP requests.
/// </summary>
[Binding]
public class HttpClientRequestStreamBindings(IHttpClientDriver httpClientDriver) : IHttpClientRequestStreamBindings
{
    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    [When("a '(.*)' request is made to '(.*)' with the contents of file '(.*)' as stream content")]
    public async Task UploadFile(string httpMethod, string url, string fileName)
    {
        await httpClientDriver.SendRequestWithStreamBody(httpMethod, url, fileName);
    }

    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content with an explicit content
    ///     type.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    /// <param name="contentType">The content type for the stream part.</param>
    [When(
        "a '(.*)' request is made to '(.*)' with the contents of file '(.*)' as stream content with content type '(.*)'")]
    public async Task UploadFile(string httpMethod, string url, string fileName, string contentType)
    {
        await httpClientDriver.SendRequestWithStreamBody(httpMethod, url, fileName, contentType);
    }
}