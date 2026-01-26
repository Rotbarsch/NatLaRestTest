using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Services.Helpers.OAuth;

internal class OAuthHelper
{
    private readonly OAuthOptions _options;
    private string? _cachedToken=null;
    private DateTime _expiresAt = DateTime.MinValue;

    internal OAuthHelper(OAuthOptions options)
    {
        _options = options;
    }

    internal async Task<string> GetOAuthToken()
    {
        // Return cached token if still valid (with safety buffer)
        if (!string.IsNullOrEmpty(_cachedToken) && DateTime.UtcNow < _expiresAt)
            return _cachedToken;

        var parameters = new Dictionary<string, string>
        {
            ["grant_type"] = _options.GrantType,
            ["client_id"] = _options.ClientId,
            ["client_secret"] = _options.ClientSecret
        };

        if (!string.IsNullOrWhiteSpace(_options.Scope))
            parameters["scope"] = _options.Scope;

        if (!string.IsNullOrWhiteSpace(_options.Audience))
            parameters["audience"] = _options.Audience;

        foreach (var kvp in GetExtraParameters(_options.ExtraParameters))
            parameters[kvp.Key] = kvp.Value;

        var request = new HttpRequestMessage(HttpMethod.Post, _options.TokenEndpoint)
        {
            Content = new FormUrlEncodedContent(parameters)
        };

        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var tokenResponse = JsonSerializer.Deserialize<OAuthTokenResponse>(json)!;

        _cachedToken = tokenResponse.AccessToken;
        _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 60); // 1 min buffer

        return _cachedToken;
    }

    private static Dictionary<string,string> GetExtraParameters(string? optionsExtraParameters)
    {
        return string.IsNullOrEmpty(optionsExtraParameters) ? 
            new() : 
            optionsExtraParameters.Split(";").ToDictionary(s => s.Split("=")[0], s => s.Split("=")[1]);
    }
}