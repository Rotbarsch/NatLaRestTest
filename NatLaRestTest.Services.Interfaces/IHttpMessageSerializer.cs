namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Provides functionality to serialize HTTP messages for logging purposes.
/// </summary>
public interface IHttpMessageSerializer
{
    /// <summary>
    /// Serializes a HTTP response message for logging.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    Task<string> SerializeHttpResponseMessage(HttpResponseMessage response);
}