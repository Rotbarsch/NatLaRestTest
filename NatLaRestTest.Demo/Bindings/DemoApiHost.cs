using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Reqnroll;

namespace NatLaRestTest.Demo.Bindings;

[Binding]
public class DemoApiHostBindings : IDisposable
{
    private static DemoApiWebAppFactory? _appFactory;


    [BeforeFeature]
    public static void ApiIsStarted()
    {
        _appFactory = new DemoApiWebAppFactory();

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

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var testHost = base.CreateHost(builder);

            builder.ConfigureWebHost(webHost =>
            {
                webHost.UseKestrel();
                webHost.UseUrls("http://localhost:5000");
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

