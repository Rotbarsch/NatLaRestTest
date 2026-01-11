using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for storing parts of the HTTP response (e.g., body) into scenario variables.
/// </summary>
[Binding]
public class HttpResponseVariableBindings
{
    private readonly IVariableDriver _variableDriver;
    private readonly IHttpClientDriver _httpClientDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseVariableBindings"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver used to store values.</param>
    /// <param name="httpClientDriver">The HTTP client driver used to access responses.</param>
    public HttpResponseVariableBindings(IVariableDriver variableDriver, IHttpClientDriver httpClientDriver)
    {
        _variableDriver = variableDriver;
        _httpClientDriver = httpClientDriver;
    }

    /// <summary>
    /// When step: Stores the body of the current HTTP response as a string in the specified variable. Asserts that a response is available.
    /// </summary>
    /// <param name="variableName">The name of the variable to store the response body.</param>
    [When("the response body is stored in variable '(.*)'")]
    public async Task StoreResponseBody(string variableName)
    {
        _variableDriver.SetVariable(variableName, await _httpClientDriver.GetCurrentResponseAsString());
    }

    /// <summary>
    /// When step: Stores the value of the specified response header into a scenario variable.
    /// </summary>
    /// <param name="headerName">The response header to read.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the value of header '(.*)' is stored in variable '(.*)'")]
    public void StoreResponseHeaderValue(string headerName, string variableName)
    {
        string headerValue = _httpClientDriver.GetCurrentResponseHeaderValue(headerName);
        _variableDriver.SetVariable(variableName, headerValue);
    }
}