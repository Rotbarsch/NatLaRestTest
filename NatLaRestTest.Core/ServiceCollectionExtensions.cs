using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Drivers;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic;
using NatLaRestTest.Logic.Interfaces;

namespace NatLaRestTest.Core;

/// <summary>
/// Provides extension methods to register NatLaRestTest drivers and logic components into an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all driver implementations used by NatLaRestTest into the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add the driver services to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance to allow method chaining.</returns>
    public static IServiceCollection RegisterNatLaRestTestDrivers(this IServiceCollection services)
    {
        services
            .AddScoped<IVariableDriver, VariableDriver>()
            .AddScoped<IHttpClientDriver, HttpClientDriver>()
            .AddScoped<IJsonPathDriver, JsonPathDriver>()
            .AddScoped<IDateTimeManipulationDriver, DateTimeManipulationDriver>()
            .AddScoped<IComparisonLogic, ComparisonLogic>()
            .AddScoped<ICollectionVariableLogic, CollectionVariableLogic>()
            .AddScoped<IRandomDataDriver, RandomDataDriver>()
            .AddScoped<IXPathDriver, XPathDriver>()
            .AddScoped<ITestOutputLoggingDriver, TestOutputLoggingDriver>();
        return services;
    }

    /// <summary>
    /// Registers all logic implementations used by NatLaRestTest into the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add the logic services to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance to allow method chaining.</returns>
    public static IServiceCollection RegisterNatLaRestTestLogics(this IServiceCollection services)
    {
        services
            .AddScoped<IBasicVariableLogic, BasicVariableLogic>()
            .AddScoped<ICollectionVariableLogic, CollectionVariableLogic>()
            .AddScoped<IDateTimeLogic, DateTimeLogic>()
            .AddScoped<IFileSystemLogic, FileSystemLogic>()
            .AddScoped<IHttpClientLogic, HttpClientLogic>()
            .AddScoped<IJsonPathLogic, JsonPathLogic>()
            .AddScoped<IJsonSchemaLogic, JsonSchemaLogic>()
            .AddScoped<INumericDriver, NumericDriver>()
            .AddScoped<IRandomizerLogic, RandomizerLogic>()
            .AddScoped<IRegExLogic, RegExLogic>()
            .AddScoped<IStringLogic, StringLogic>()
            .AddScoped<IXmlLogic, XmlLogic>();

        return services;
    }
}