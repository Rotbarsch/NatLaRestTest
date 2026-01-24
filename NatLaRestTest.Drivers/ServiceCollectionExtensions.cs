using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Drivers.Interfaces;

namespace NatLaRestTest.Drivers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaRestTestDrivers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IBasicVariableDriver, BasicVariableDriver>()
            .AddScoped<IBoolVariableDriver, BoolVariableDriver>()
            .AddScoped<ICollectionVariableDriver, CollectionVariableDriver>()
            .AddScoped<IDateTimeDriver, DateTimeDriver>()
            .AddScoped<IFileSystemDriver, FileSystemDriver>()
            .AddScoped<IHttpClientDriver, HttpClientDriver>()
            .AddScoped<IJsonPathDriver, JsonPathDriver>()
            .AddScoped<IJsonSchemaDriver, JsonSchemaDriver>()
            .AddScoped<IRandomizerDriver, RandomizerDriver>()
            .AddScoped<IRegExDriver, RegExDriver>()
            .AddScoped<IStopwatchDriver, StopwatchDriver>()
            .AddScoped<IStringDriver, StringDriver>()
            .AddScoped<IWaitDriver, WaitDriver>()
            .AddScoped<IXmlDriver, XmlDriver>();

        return serviceCollection;
    }
}