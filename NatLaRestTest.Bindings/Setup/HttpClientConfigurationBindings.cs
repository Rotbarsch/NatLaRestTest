using NatLaRestTest.Bindings.Interfaces.Setup;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Setup;

/// <summary>
///     Step bindings to configure the shared HTTP client used across scenarios (base URL, timeout, headers).
/// </summary>
[Binding]
public class HttpClientConfigurationBindings(IHttpClientDriver httpClientDriver) : IHttpClientConfigurationBindings
{
    /// <summary>
    ///     Given step: Configures the base address used by the shared HTTP client.
    /// </summary>
    /// <param name="baseUrl">The absolute base URL (e.g., https://api.example.com).</param>
    [Given("the base URL '(.*)'")]
    public void SetBaseUrl(string baseUrl)
    {
        httpClientDriver.SetBaseUrl(baseUrl);
    }

    /// <summary>
    ///     Given step: Sets the default timeout for HTTP requests executed by the shared HTTP client.
    /// </summary>
    /// <param name="seconds">The timeout value in seconds.</param>
    [Given("the default timeout of '(.*)' seconds")]
    public void SetDefaultTimeout(int seconds)
    {
        httpClientDriver.SetDefaultTimeout(seconds);
    }

    /// <summary>
    ///     Given step: Adds a default request header to the shared HTTP client.
    /// </summary>
    /// <param name="headerName">The name of the header to add.</param>
    /// <param name="headerValue">The value of the header.</param>
    [Given("the default header '(.*)' with value '(.*)'")]
    public void SetDefaultHeader(string headerName, string headerValue)
    {
        httpClientDriver.SetDefaultHeader(headerName, headerValue);
    }

    /// <summary>
    ///     Given step: Disables SSL certificate validation for outgoing requests.
    /// </summary>
    [Given("SSL certificate validation is disabled")]
    public void DisableSslCertificateValidation()
    {
        httpClientDriver.DisableSslCertificateValidation();
    }

    /// <summary>
    /// Given step: Enabled NTLM authentication for outgoing requests, using the executing user as credential.
    /// </summary>
    [Given("NTLM authentication is enabled")]
    public void EnableNtlmAuthentication()
    {
        httpClientDriver.EnableNtlmAuthentication();
    }
}