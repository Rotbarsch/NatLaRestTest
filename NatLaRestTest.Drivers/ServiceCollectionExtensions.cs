using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Drivers.Interfaces;

namespace NatLaRestTest.Drivers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaRestTestDrivers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IHttpClientDriver, HttpClientDriver>();

        return serviceCollection;
    }
}