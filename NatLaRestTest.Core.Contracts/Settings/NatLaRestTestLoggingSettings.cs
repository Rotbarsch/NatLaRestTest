namespace NatLaRestTest.Core.Contracts.Settings;

public record NatLaRestTestLoggingSettings
{
    public bool FormatJson { get; init; } = true;
    public bool FormatXml { get; init; } = true;
    public int? MaxLoggedContentLength { get; init; } = null;
}