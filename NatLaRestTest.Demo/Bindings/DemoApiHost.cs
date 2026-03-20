using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using NatLaRestTest.Services;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Demo.Bindings;

[Binding]
public class DemoApiHostBindings : IDisposable
{
    private static DemoApiWebAppFactory? _appFactory;

    [BeforeTestRun]
    public static void ApiIsStarted()
    {

        var settingsService = new NatLaRestTestSettingsService();
        var url = settingsService.GetVariables().Single(x => x.Name == "demoApiBaseUrl").Value!;
        
        _appFactory = new DemoApiWebAppFactory(url);
        _appFactory.StartServer();
    }

    public void Dispose()
    {
        _appFactory?.Dispose();
        GC.SuppressFinalize(this);
    }

    internal class DemoApiWebAppFactory : WebApplicationFactory<Program>
    {
        private IHost? _kestrelHost;
        private readonly string _url;

        public DemoApiWebAppFactory(string url) : base()
        {
            _url = url;
        }


        protected override IHost CreateHost(IHostBuilder builder)
        {
            var testHost = base.CreateHost(builder);

            builder.ConfigureWebHost(webHost =>
            {
                webHost.UseKestrel();
                webHost.UseUrls(_url);
            });

            _kestrelHost = builder.Build();
            _kestrelHost.Start();

            return testHost; // Return test host instead of kestrel host to prevent casting exceptions further down the line.
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _kestrelHost?.Dispose();
        }

        public void StartServer()
        {
            var _ = Server; // the getter of Server will trigger the CreateHost method, which starts the Kestrel server.
        }
    }
}

