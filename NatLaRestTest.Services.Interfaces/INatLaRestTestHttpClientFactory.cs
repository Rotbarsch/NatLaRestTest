namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Creates instances of HttpClients.
/// </summary>
public interface INatLaRestTestHttpClientFactory
{
    /// <summary>
    /// Creates a new instance of the HttpClient. The <see cref="HttpClientHandler"/> instance will be setup by the <see cref="IHttpClientService"/>
    /// for configuration via bindings (BaseUrl, Headers, etc.).
    /// </summary>
    /// <param name="httpClientHandler">Underlying HttpClientHandler to use.</param>
    /// <returns>Configured instance of HttpClient.</returns>
    HttpClient CreateHttpClient(HttpClientHandler httpClientHandler);
}