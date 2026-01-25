using System.Globalization;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
/// Service for getting CultureInfo from configuration.
/// </summary>
public class CultureInfoService : ICultureInfoService
{
    private string _culture = "en-US";

    public CultureInfoService()
    {
        GetConfiguredCulture();
    }

    /// <summary>
    /// Returns the culture info configured in reqnroll.json. Defaults to "en-US".
    /// </summary>
    /// <returns>The configured CultureInfo.</returns>
    public CultureInfo GetConfiguredCultureInfo()
    {
        return CultureInfo.GetCultureInfo(_culture);
    }

    private void GetConfiguredCulture()
    {
        var filePath = "reqnroll.json";

        var fileExists = File.Exists(filePath);
        if (!fileExists)
        {
            Assert.Fail($"File '{filePath}' does not exist.");
        }

        var json = File.ReadAllText(filePath);
        var jToken = JToken.Parse(json);
        _culture = jToken.SelectToken("$.language.feature")?.Value<string>() ?? "en-US";
    }
}