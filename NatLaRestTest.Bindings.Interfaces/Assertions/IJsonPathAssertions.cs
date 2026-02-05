namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface IJsonPathAssertions
{
    /// <summary>
    ///     Then step: Asserts a JSONPath is resolvable on the content of a variable.
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    void AssertJsonPathIsValid(string jPath, string sourceVariableName);

    /// <summary>
    ///     Then step: Asserts a JSONPath is not resolvable on the content of a variable (the property does not exist).
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    void AssertJsonPathIsInvalid(string jPath, string sourceVariableName);
}