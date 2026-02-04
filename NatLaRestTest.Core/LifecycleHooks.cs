using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Core;

/// <summary>
/// Default class for adding hooks for Reqnroll lifecycle.
/// </summary>
/// <param name="loggingService">Logger.</param>
/// <param name="settingsService">SettingsService.</param>
[Binding]
public class LifecycleHooks(ITestOutputLoggingService loggingService, INatLaRestTestSettingsService settingsService)
{
    [BeforeScenario]
    public void OnBeforeScenario()
    {
        var loadedSettingsFiles = settingsService.GetLoadedSettingsFiles();
        loggingService.WriteLine($"Loaded and applied the following NatLaRestTestSettings.json files: {string.Join(", ", loadedSettingsFiles)}");
    }
}