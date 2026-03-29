using NatLaRestTest.Core.Contracts.Settings;
using NatLaRestTest.Services.Helpers.HttpMessageContentBeautifier;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

public class ContentStringBeautifier(INatLaRestTestSettingsService settingsService) : IContentStringBeautifier
{
    private readonly NatLaRestTestLoggingSettings _loggingSettings = settingsService.GetLoggingSettings();

    public string Beautify(string contentString, string? contentType)
    {
        // If for some reason the content type header does not match the actual content, we don't want logging to fail.
        try
        {
            return contentType switch
            {
                null => contentString,
                var ct when ct.StartsWith("application/json") && _loggingSettings.FormatJson => new JsonContentStringBeautifier().Beautify(contentString),
                var ct when ct.StartsWith("application/xml") && _loggingSettings.FormatXml => new XmlContentStringBeautifier().Beautify(contentString),
                _ => contentString,
            };
        }
        catch
        {
            return contentString;
        }
    }

    public string EnforceLength(string contentString)
    {
        if(!_loggingSettings.MaxLoggedContentLength.HasValue) return contentString;

        return contentString.Length > _loggingSettings.MaxLoggedContentLength ? contentString[.._loggingSettings.MaxLoggedContentLength.Value] : contentString;
    }
}