using System.Diagnostics;
using System.Net.Sockets;
using Reqnroll;
using Rotbarsch.Reqnroll.Services;

namespace NatLaRestTest.Demo.Bindings;

[Binding]
public class DemoApiHostBindings
{
    private const string ApiAssemblyFileName = "NatLaRestTest.DemoWebApi.dll";

    private static Process? _apiProcess;

    [BeforeTestRun]
    public static void StartDemoApi()
    {
        var settingsService = new RotbarschReqnrollSettingsService();
        var url = settingsService.GetVariables().Single(x => x.Name == "demoApiBaseUrl").Value!;

        var apiAssemblyPath = Path.Combine(AppContext.BaseDirectory, ApiAssemblyFileName);

        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            WorkingDirectory = AppContext.BaseDirectory,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };
        startInfo.ArgumentList.Add(apiAssemblyPath);
        startInfo.ArgumentList.Add("--urls");
        startInfo.ArgumentList.Add(url);

        _apiProcess = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
        _apiProcess.Start();

        WaitForWebApiReady(url);
    }

    [AfterTestRun]
    public static void StopDemoApi()
    {
        if (_apiProcess is null)
        {
            return;
        }

        try
        {
            if (!_apiProcess.HasExited)
            {
                _apiProcess.Kill(entireProcessTree: true);
                _apiProcess.WaitForExit(5000);
            }
        }
        finally
        {
            _apiProcess.Dispose();
            _apiProcess = null;
        }
    }

    private static void WaitForWebApiReady(string url, int timeoutSeconds = 30)
    {
        var uri = new Uri(url);
        var deadline = DateTime.UtcNow.AddSeconds(timeoutSeconds);

        while (DateTime.UtcNow < deadline)
        {
            if (_apiProcess is { HasExited: true })
            {
                throw new InvalidOperationException(
                    $"DemoWebApi process exited prematurely with code {_apiProcess.ExitCode}. Check '{ApiAssemblyFileName}' in '{AppContext.BaseDirectory}'.");
            }

            try
            {
                using var tcpClient = new TcpClient();
                tcpClient.Connect(uri.Host, uri.Port);
                return;
            }
            catch (SocketException)
            {
                Thread.Sleep(200);
            }
        }

        throw new TimeoutException($"Timed out waiting for DemoWebApi to start listening on '{url}'.");
    }
}

