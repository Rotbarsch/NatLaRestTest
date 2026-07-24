using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaRestTestServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IContentStringBeautifier, ContentStringBeautifier>()
            .AddScoped<IHttpClientService, HttpClientService>()
            .AddScoped<IHttpMessageSerializer, HttpMessageSerializer>()
            .AddScoped<INatLaRestTestHttpClientFactory, NatLaRestTestHttpClientFactory>();
            
        return serviceCollection;
    }
}