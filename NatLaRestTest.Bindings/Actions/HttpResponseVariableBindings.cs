using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for storing parts of the HTTP response (e.g., body) into scenario variables.
/// </summary>
[Binding]
public class HttpResponseVariableBindings : IHttpResponseVariableBindings
{
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="HttpResponseVariableBindings" /> class.
    /// </summary>
    /// <param name="httpClientDriver">Driver component used to access the current HTTP response and store values.</param>
    public HttpResponseVariableBindings(IHttpClientDriver httpClientDriver)
    {
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    ///     When step: Stores the body of the current HTTP response as a string in the specified variable. Asserts that a
    ///     response is available.
    /// </summary>
    /// <param name="variableName">The name of the variable to store the response body.</param>
    [When("the response body is stored in variable '(.*)'")]
    public async Task StoreResponseBody(string variableName)
    {
        await _httpClientDriver.StoreResponseBodyInVariable(variableName);
    }

    /// <summary>
    ///     When step: Stores the value of the specified response header into a scenario variable.
    /// </summary>
    /// <param name="headerName">The response header to read.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the value of header '(.*)' is stored in variable '(.*)'")]
    public void StoreResponseHeaderValue(string headerName, string variableName)
    {
        _httpClientDriver.StoreResponseHeaderValueInVariable(headerName, variableName);
    }

    /// <summary>
    /// When step: Stores the response time (in milliseconds) of the current HTTP response into a scenario variable.
    /// </summary>
    /// <param name="variableName"></param>
    [When("the response time is stored in variable '(.*)'")]
    public void StoreResponseTime(string variableName)
    {
        _httpClientDriver.StoreResponseTimeInVariable(variableName);
    }
}