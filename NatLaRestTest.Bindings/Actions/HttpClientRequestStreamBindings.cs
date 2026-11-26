using System.Text;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for uploading files as stream content in HTTP requests.
/// </summary>
[Binding]
public class HttpClientRequestStreamBindings(IHttpClientDriver httpClientDriver)
{
    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    [When("^a '([^']*)' request is made to '([^']*)' with the contents of file '([^']*)' as stream content$")]
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
    [When("^a '([^']*)' request is made to '([^']*)' with the contents of file '([^']*)' as stream content with content type '([^']*)'$")]
    public async Task UploadFile(string httpMethod, string url, string fileName, string contentType)
    {
        await httpClientDriver.SendRequestWithStreamBody(httpMethod, url, fileName, contentType);
    }

    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content with an explicit content
    ///     type and form field name.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    /// <param name="contentType">The content type for the stream part.</param>
    /// <param name="formFieldName">The form field name for the file part.</param>
    [When("^a '([^']*)' request is made to '([^']*)' with the contents of file '([^']*)' as stream content with content type '([^']*)' and form field name '([^']*)'$")]
    public async Task UploadFileWithFormFieldName(string httpMethod, string url, string fileName, string contentType, string formFieldName)
    {
        await httpClientDriver.SendRequestWithStreamBody(httpMethod, url, fileName, contentType, formFieldName);
    }

    /// <summary>
    ///     When step: Uploads string content as a multipart file part directly from memory.
    ///     The string is encoded as UTF-8 and is not written to a temporary file.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST or PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileContent">The text payload to upload.</param>
    /// <param name="fileName">The filename reported for the multipart file part.</param>
    /// <param name="contentType">The MIME type for the multipart file part.</param>
    /// <param name="formFieldName">The multipart form field name.</param>
    [When("^a '([^']*)' request is made to '([^']*)' with string content '([^']*)' as multipart file '([^']*)' with content type '([^']*)' and form field name '([^']*)'$")]
    public async Task UploadStringContentAsMultipartFile(
        string httpMethod,
        string url,
        string fileContent,
        string fileName,
        string contentType,
        string formFieldName)
    {
        await httpClientDriver.SendRequestWithMultipartFileContent(
            httpMethod,
            url,
            fileName,
            fileContent,
            contentType,
            formFieldName);
    }
}