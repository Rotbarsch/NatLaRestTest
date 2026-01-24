using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing assertions for the current HTTP response (status success, exact/not-equal status codes).
/// </summary>
[Binding]
public class HttpResponseAssertionBindings(IHttpClientDriver httpClientDriver) : IHttpResponseAssertionBindings
{
    /// <summary>
    ///     Then step: Asserts that the current HTTP response exists and indicates success (2xx status).
    /// </summary>
    [Then("the response indicates success")]
    public void ResponseIsSuccess()
    {
        httpClientDriver.ResponseIsSuccess();
    }

    /// <summary>
    ///     Then step: Asserts that the current HTTP response exists and does not indicate success.
    /// </summary>
    [Then("the response does not indicate success")]
    public void ResponseIsNotSuccess()
    {
        httpClientDriver.ResponseIsNotSuccess();
    }

    /// <summary>
    ///     Then step: Asserts that the current HTTP response status code equals the expected value.
    /// </summary>
    /// <param name="code">The expected HTTP status code (e.g., 200).</param>
    [Then("the response code equals '(.*)'")]
    public void AssertResponseCode(int code)
    {
        httpClientDriver.AssertResponseCode(code);
    }

    /// <summary>
    ///     Then step: Asserts that the current HTTP response status code does not equal the specified value.
    /// </summary>
    /// <param name="code">The HTTP status code that must not match.</param>
    [Then("the response code does not equal '(.*)'")]
    public void AssertResponseCodeIsNot(int code)
    {
        httpClientDriver.AssertResponseCodeIsNot(code);
    }
}