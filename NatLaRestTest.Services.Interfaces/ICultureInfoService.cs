using System.Globalization;

namespace NatLaRestTest.Services.Interfaces;

/// <summary>
/// Service for getting CultureInfo from configuration.
/// </summary>
public interface ICultureInfoService
{
    /// <summary>
    /// Returns the culture info configured in reqnroll.json. Defaults to "en-US".
    /// </summary>
    /// <returns>The configured CultureInfo.</returns>
    CultureInfo GetConfiguredCultureInfo();
}