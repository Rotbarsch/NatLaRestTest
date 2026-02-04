using NatLaRestTest.Core.Contracts.Settings;

namespace NatLaRestTest.Services.Interfaces;

public interface INatLaRestTestSettingsService
{
    /// <summary>
    /// Returns configured global variables.
    /// </summary>
    /// <returns>All variables as defined in settings.</returns>
    IEnumerable<SettingsVariable> GetVariables();

    /// <summary>
    /// Returns configured file redirects.
    /// </summary>
    /// <returns>All file redirects as defined in settings.</returns>
    IEnumerable<FileRedirect> GetFileRedirects();

    /// <summary>
    /// Returns paths of all actually loaded settings files.
    /// </summary>
    /// <returns>List of file paths.</returns>
    IEnumerable<string> GetLoadedSettingsFiles();
}