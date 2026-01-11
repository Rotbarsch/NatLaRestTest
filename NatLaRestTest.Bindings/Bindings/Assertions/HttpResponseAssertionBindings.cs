using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing assertions for the current HTTP response (status success, exact/not-equal status codes).
/// </summary>
[Binding]
public class HttpResponseAssertionBindings
{
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseAssertionBindings"/> class.
    /// </summary>
    /// <param name="httpClientDriver">The HTTP client driver dependency.</param>
    public HttpResponseAssertionBindings(IHttpClientDriver httpClientDriver)
    {
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    /// Then step: Asserts that the current HTTP response exists and indicates success (2xx status).
    /// </summary>
    [Then("the response indicates success")]
    public void ResponseIsSuccess()
    {
        Assert.IsTrue(_httpClientDriver.CurrentResponseIsSuccessful(), $"Response status code {_httpClientDriver.GetCurrentResponseStatusCode()} does not indicate success.");
    }

    /// <summary>
    /// Then step: Asserts that the current HTTP response exists and does not indicate success.
    /// </summary>
    [Then("the response does not indicate success")]
    public void ResponseIsNotSuccess()
    {
        Assert.IsFalse(_httpClientDriver.CurrentResponseIsSuccessful(), $"Response status code {_httpClientDriver.GetCurrentResponseStatusCode()} does indicate success.");
    }

    /// <summary>
    /// Then step: Asserts that the current HTTP response status code equals the expected value.
    /// </summary>
    /// <param name="code">The expected HTTP status code (e.g., 200).</param>
    [Then("the response code equals '(.*)'")]
    public void AssertResponseCode(int code)
    {
        Assert.AreEqual(code, _httpClientDriver.GetCurrentResponseStatusCode(), $"Expected response code {code} but got {_httpClientDriver.GetCurrentResponseStatusCode()}");
    }

    /// <summary>
    /// Then step: Asserts that the current HTTP response status code does not equal the specified value.
    /// </summary>
    /// <param name="code">The HTTP status code that must not match.</param>
    [Then("the response code does not equal '(.*)'")]
    public void AssertResponseCodeIsNot(int code)
    {
        Assert.AreNotEqual(code, _httpClientDriver.GetCurrentResponseStatusCode(), $"Expected response code to not be equal {code}.");
    }

}