namespace NatLaRestTest.Core.Contracts.Settings;

public record FileRedirect
{
    public required string OriginalFileName { get; set; }
    public required string Redirect { get; set; }
}