using Microsoft.Extensions.DependencyInjection;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaRestTestServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IBoolService, BoolService>()
            .AddScoped<IComparisonService, ComparisonService>()
            .AddScoped<IDateTimeManipulationService, DateTimeManipulationService>()
            .AddScoped<IHttpClientService, HttpClientService>()
            .AddScoped<IJsonPathService, JsonPathService>()
            .AddScoped<INumericService, NumericService>()
            .AddScoped<IRandomDataService, RandomDataService>()
            .AddScoped<ITestOutputLoggingService, TestOutputLoggingService>()
            .AddScoped<IVariableService, VariableService>()
            .AddScoped<IXPathService, XPathService>();

        return serviceCollection;
    }
}