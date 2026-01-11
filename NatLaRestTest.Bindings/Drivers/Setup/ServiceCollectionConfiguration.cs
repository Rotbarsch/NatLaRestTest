using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Bindings.Drivers.Interfaces;

namespace NatLaRestTest.Bindings.Drivers.Setup;

/// <summary>
/// Configures dependency injection for driver services.
/// </summary>
internal static class ServiceCollectionConfiguration
{
    /// <summary>
    /// Registers driver services and returns the configured <see cref="ServiceCollection"/>.
    /// </summary>
    /// <returns>The service collection with driver registrations.</returns>
    public static ServiceCollection SetupDrivers()
    {
        var services = new ServiceCollection();

        services
            .AddScoped<IVariableDriver, VariableDriver>()
            .AddScoped<IHttpClientDriver,HttpClientDriver>()
            .AddScoped<IJsonPathDriver, JsonPathDriver>()
            .AddScoped<IDateTimeManipulationDriver, DateTimeManipulationDriver>()
            .AddScoped<INumericManipulationDriver, NumericManipulationDriver>()
            .AddScoped<IRandomDataDriver, RandomDataDriver>()
            .AddScoped<IXPathDriver, XPathDriver>()
            .AddScoped<ITestOutputLoggingDriver, TestOutputLoggingDriver>();

        return services;
    }
}