using NatLaRestTest.Core.Contracts.Settings;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace NatLaRestTest.Services;

/// <summary>
/// Service for interacting with NatLaRestTestSettings.json file.
/// </summary>
public class NatLaRestTestSettingsService : INatLaRestTestSettingsService
{
    private readonly NatLaRestTestSettings _settings;
    private readonly List<string> LoadedSettingsFiles = new();
    private static readonly string SettingsFileName = "NatLaRestTestSettings.json";

    public NatLaRestTestSettingsService()
    {
        //_loggingService = loggingService;
        _settings = ConstructSettings();
    }

    /// <summary>
    /// Returns configured global variables.
    /// </summary>
    /// <returns>All variables as defined in settings.</returns>
    public IEnumerable<SettingsVariable> GetVariables() => _settings.GlobalVariables;

    /// <summary>
    /// Returns configured file redirects.
    /// </summary>
    /// <returns>All file redirects as defined in settings.</returns>
    public IEnumerable<FileRedirect> GetFileRedirects() => _settings.FileRedirects;

    /// <summary>
    /// Returns paths of all actually loaded settings files.
    /// </summary>
    /// <returns>List of file paths.</returns>
    public IEnumerable<string> GetLoadedSettingsFiles() => LoadedSettingsFiles;

    private NatLaRestTestSettings ConstructSettings()
    {
        if (!File.Exists(SettingsFileName)) return new NatLaRestTestSettings();
        var json = File.ReadAllText(SettingsFileName);
        var settingsObject = JObject.Parse(json) ?? JObject.FromObject(new NatLaRestTestSettings());
        LoadedSettingsFiles.Add(SettingsFileName);

        if (settingsObject.TryGetValue("additionalConfigurationFiles", out var additionalConfigurationFilesToken))
        {
            foreach (var additionalContentFile in additionalConfigurationFilesToken.Values<string>())
            {
                TryMergeIntoSettingsObject(ref settingsObject, additionalContentFile);
            }
        }

        return settingsObject.ToObject<NatLaRestTestSettings>() ?? new NatLaRestTestSettings();
    }

    private void TryMergeIntoSettingsObject(ref JObject settingsObject, string? additionalContentFile)
    {
        if (string.IsNullOrEmpty(additionalContentFile) || !File.Exists(additionalContentFile))
        {
            return;
        }

        var subJson = File.ReadAllText(additionalContentFile);
        var subObject = JObject.Parse(subJson);

        if (subObject.TryGetValue("additionalConfigurationFiles", out var additionalConfigurationFilesToken))
        {
            foreach (var subAdditionalContentFile in additionalConfigurationFilesToken.Values<string>())
            {
                TryMergeIntoSettingsObject(ref subObject, subAdditionalContentFile);
            }
        }

        settingsObject.Merge(subObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        LoadedSettingsFiles.Add(additionalContentFile);
    }
}