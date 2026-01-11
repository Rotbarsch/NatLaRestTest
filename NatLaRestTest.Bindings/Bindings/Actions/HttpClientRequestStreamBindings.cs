using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for uploading files as stream content in HTTP requests.
/// </summary>
[Binding]
public class HttpClientRequestStreamBindings
{
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestStreamBindings"/> class.
    /// </summary>
    /// <param name="httpClientDriver">The HTTP client driver dependency.</param>
    public HttpClientRequestStreamBindings(IHttpClientDriver httpClientDriver)
    {
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    /// When step: Sends an HTTP request and uploads the contents of a file as stream content.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    [When("a '(.*)' request is made to '(.*)' with the contents of file '(.*)' as stream content")]
    public async Task UploadFile(string httpMethod, string url, string fileName)
    {
        await _httpClientDriver.SendRequestWithStreamBody(httpMethod,url,fileName);
    }

    /// <summary>
    /// When step: Sends an HTTP request and uploads the contents of a file as stream content with an explicit content type.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    /// <param name="contentType">The content type for the stream part.</param>
    [When("a '(.*)' request is made to '(.*)' with the contents of file '(.*)' as stream content with content type '(.*)'")]
    public async Task UploadFile(string httpMethod, string url, string fileName, string contentType)
    {
        await _httpClientDriver.SendRequestWithStreamBody(httpMethod,url,fileName,contentType);
    }
}