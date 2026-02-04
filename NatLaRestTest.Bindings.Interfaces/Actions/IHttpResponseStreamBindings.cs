namespace NatLaRestTest.Bindings.Interfaces.Actions;

public interface IHttpResponseStreamBindings
{
    /// <summary>
    ///     When step: Saves the current response stream to a file.
    /// </summary>
    /// <param name="filePath">The target file path.</param>
    Task SaveResponseStreamToFile(string filePath);

    /// <summary>
    ///     When step: Stores the length of the current response stream (in bytes) into a scenario variable.
    /// </summary>
    /// <param name="variableName">The target variable name.</param>
    Task StoreResponseStreamLengthInVariable(string variableName);
}