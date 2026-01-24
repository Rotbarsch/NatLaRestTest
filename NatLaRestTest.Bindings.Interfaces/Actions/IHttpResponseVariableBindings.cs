namespace NatLaRestTest.Bindings.Interfaces.Actions;

public interface IHttpResponseVariableBindings
{
    /// <summary>
    ///     When step: Stores the body of the current HTTP response as a string in the specified variable. Asserts that a
    ///     response is available.
    /// </summary>
    /// <param name="variableName">The name of the variable to store the response body.</param>
    Task StoreResponseBody(string variableName);

    /// <summary>
    ///     When step: Stores the value of the specified response header into a scenario variable.
    /// </summary>
    /// <param name="headerName">The response header to read.</param>
    /// <param name="variableName">The target variable name.</param>
    void StoreResponseHeaderValue(string headerName, string variableName);
}