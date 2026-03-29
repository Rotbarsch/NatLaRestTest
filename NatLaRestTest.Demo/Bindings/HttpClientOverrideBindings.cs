using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Core;
using NatLaRestTest.Services;
using NatLaRestTest.Services.Interfaces;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace NatLaRestTest.Demo.Bindings;

/// <summary>
/// This is just an example how to override the <see cref="INatLaRestTestHttpClientFactory"/> in order to modify the used HttpClient instances.
/// </summary>
public class HttpClientOverrideBindings
{
    /// <summary>
    /// By using the <see cref="DependencyInjectionSetup"/>.Services property, you can access the <see cref="IServiceCollection"/>
    /// used for setting up the services underneath NatLaRestTest. This allows overriding the default implementations in NatLaRestTest.Services
    /// with custom implementations. This example demonstrates how to do so in order to override the behaviour of <see cref="NatLaRestTestHttpClientFactory"/>.
    /// </summary>
    /// <returns>Updated <see cref="IServiceCollection"/>.</returns>
    [ScenarioDependencies]
    public static IServiceCollection OverrideHttpClientFactory()
    {
        var natLaServices = DependencyInjectionSetup.Services;
        natLaServices.AddScoped<INatLaRestTestHttpClientFactory, CustomHttpClientFactory>();
        return natLaServices;
    }

    /// <summary>
    /// Example for a modified HttpClientFactory.
    /// </summary>
    internal class CustomHttpClientFactory : NatLaRestTestHttpClientFactory
    {
        public override HttpClient CreateHttpClient(HttpClientHandler httpClientHandler)
        {
            var client =  base.CreateHttpClient(httpClientHandler);
            // You would do something with the handler or the client here. Instead, we only write to the console for demonstration purposes.
            Console.WriteLine("Instantiated custom HTTP client.");
            return client;
        }
    }
}