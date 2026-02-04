namespace NatLaRestTest.Core.Contracts;

public record OAuthOptions
{
    public required string TokenEndpoint { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public string Scope { get; set; } = "";      // space-separated if multiple
    public string GrantType { get; set; } = "client_credentials";
    public string Audience { get; set; } = "";   // Some providers (Auth0) use this
    public string? ExtraParameters { get; set; }
}