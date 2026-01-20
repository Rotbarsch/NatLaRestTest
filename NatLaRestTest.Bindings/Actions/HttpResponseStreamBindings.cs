using System.Threading.Tasks;
using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
///     Step bindings for working with HTTP response streams, including saving to a file and storing the stream length.
/// </summary>
[Binding]
public class HttpResponseStreamBindings(IHttpClientLogic httpClientLogic) : IHttpResponseStreamBindings
{
    /// <summary>
    ///     When step: Saves the current response stream to a file.
    /// </summary>
    /// <param name="filePath">The target file path.</param>
    [When("the response stream is saved to file '(.*)'")]
    public async Task SaveResponseStreamToFile(string filePath)
    {
        await httpClientLogic.SaveResponseStreamToFile(filePath);
    }

    /// <summary>
    ///     When step: Stores the length of the current response stream (in bytes) into a scenario variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    [When("the length of the response stream is stored in variable '(.*)'")]
    public async Task StoreResponseStreamLengthInVariable(string variableName)
    {
        await httpClientLogic.StoreResponseStreamLengthInVariable(variableName);
    }
}