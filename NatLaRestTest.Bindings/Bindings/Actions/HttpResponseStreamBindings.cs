using Reqnroll;
using NatLaRestTest.Bindings.Drivers.Interfaces;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for working with HTTP response streams, including saving to a file and storing the stream length.
/// </summary>
[Binding]
public class HttpResponseStreamBindings
{
    private readonly IHttpClientDriver _httpClientDriver;
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseStreamBindings"/> class.
    /// </summary>
    /// <param name="httpClientDriver">The HTTP client driver dependency.</param>
    /// <param name="variableDriver">The variable driver used to store values.</param>
    public HttpResponseStreamBindings(IHttpClientDriver httpClientDriver, IVariableDriver variableDriver)
    {
        _httpClientDriver = httpClientDriver;
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// When step: Saves the current response stream to a file.
    /// </summary>
    /// <param name="filePath">The target file path.</param>
    [When("the response stream is saved to file '(.*)'")]
    public async Task SaveResponseStreamToFile(string filePath)
    {
        await _httpClientDriver.SaveResponseStreamToFile(filePath);
    }

    /// <summary>
    /// When step: Stores the length of the current response stream (in bytes) into a scenario variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    [When("the length of the response stream is stored in variable '(.*)'")]
    public async Task StoreResponseStreamLengthInVariable(string variableName)
    {
        long length = await _httpClientDriver.GetResponseStreamLength();
        _variableDriver.SetVariable(variableName, length.ToString());
    }
}