using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Setup;

/// <summary>
/// Step bindings to configure the shared HTTP client used across scenarios (base URL, timeout, headers).
/// </summary>
[Binding]
public class HttpClientConfigurationBindings
{
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientConfigurationBindings"/> class.
    /// </summary>
    /// <param name="httpClientDriver">The HTTP client driver dependency.</param>
    public HttpClientConfigurationBindings(IHttpClientDriver httpClientDriver)
    {
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    /// Given step: Configures the base address used by the shared HTTP client.
    /// </summary>
    /// <param name="baseUrl">The absolute base URL (e.g., https://api.example.com).</param>
    [Given("the base URL '(.*)'")]
    public void SetBaseUrl(string baseUrl)
    {
        _httpClientDriver.SetBaseAddress(baseUrl);
    }

    /// <summary>
    /// Given step: Sets the default timeout for HTTP requests executed by the shared HTTP client.
    /// </summary>
    /// <param name="seconds">The timeout value in seconds.</param>
    [Given("the default timeout of '(.*)' seconds")]
    public void SetDefaultTimeout(int seconds)
    {
        _httpClientDriver.SetDefaultTimeout(seconds);
    }

    /// <summary>
    /// Given step: Adds a default request header to the shared HTTP client.
    /// </summary>
    /// <param name="headerName">The name of the header to add.</param>
    /// <param name="headerValue">The value of the header.</param>
    [Given("the default header '(.*)' with value '(.*)'")]
    public void SetDefaultHeader(string headerName, string headerValue)
    {
        _httpClientDriver.SetDefaultHeader(headerName, headerValue);
    }

    /// <summary>
    /// Given step: Disables SSL certificate validation for outgoing requests.
    /// </summary>
    [Given("SSL certificate validation is disabled")]
    public void DisableSslCertificateValidation()
    {
        _httpClientDriver.DisableSslCertificateValidation();
    }
}