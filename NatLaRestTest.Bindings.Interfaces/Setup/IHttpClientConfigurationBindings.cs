namespace NatLaRestTest.Bindings.Interfaces.Setup;

public interface IHttpClientConfigurationBindings
{
    /// <summary>
    ///     Given step: Configures the base address used by the shared HTTP client.
    /// </summary>
    /// <param name="baseUrl">The absolute base URL (e.g., https://api.example.com).</param>
    void SetBaseUrl(string baseUrl);

    /// <summary>
    ///     Given step: Sets the default timeout for HTTP requests executed by the shared HTTP client.
    /// </summary>
    /// <param name="seconds">The timeout value in seconds.</param>
    void SetDefaultTimeout(int seconds);

    /// <summary>
    ///     Given step: Adds a default request header to the shared HTTP client.
    /// </summary>
    /// <param name="headerName">The name of the header to add.</param>
    /// <param name="headerValue">The value of the header.</param>
    void SetDefaultHeader(string headerName, string headerValue);

    /// <summary>
    ///     Given step: Disables SSL certificate validation for outgoing requests.
    /// </summary>
    void DisableSslCertificateValidation();
}