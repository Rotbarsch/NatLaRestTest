using System.Threading.Tasks;

namespace NatLaRestTest.Bindings.Interfaces.Actions;

public interface IHttpClientRequestStreamBindings
{
    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    Task UploadFile(string httpMethod, string url, string fileName);

    /// <summary>
    ///     When step: Sends an HTTP request and uploads the contents of a file as stream content with an explicit content
    ///     type.
    /// </summary>
    /// <param name="httpMethod">The HTTP method (e.g., POST, PUT).</param>
    /// <param name="url">The absolute or relative URL to request.</param>
    /// <param name="fileName">The path to the file whose contents will be uploaded.</param>
    /// <param name="contentType">The content type for the stream part.</param>
    Task UploadFile(string httpMethod, string url, string fileName, string contentType);
}