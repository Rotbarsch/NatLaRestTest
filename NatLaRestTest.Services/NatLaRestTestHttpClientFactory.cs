using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

public class NatLaRestTestHttpClientFactory : INatLaRestTestHttpClientFactory
{
    public virtual HttpClient CreateHttpClient(HttpClientHandler httpClientHandler)
    {
        return new HttpClient(httpClientHandler);
    }
}