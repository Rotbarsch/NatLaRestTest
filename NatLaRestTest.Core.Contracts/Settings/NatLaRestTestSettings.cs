namespace NatLaRestTest.Core.Contracts.Settings;

public record NatLaRestTestSettings
{
    public List<string> AdditionalConfigurationFiles { get; init; } = [];

    public List<SettingsVariable> GlobalVariables { get; init; } = [];

    public List<FileRedirect> FileRedirects { get; init; } = [];
}