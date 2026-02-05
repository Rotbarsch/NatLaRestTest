using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings for checking values from JSON variables using JSONPath (the property does exist).
/// </summary>
/// <param name="jsonPathDriver">Driver component used to evaluate JSONPath and set variables.</param>
[Binding]
public class JsonPathAssertions(IJsonPathDriver jsonPathDriver) : IJsonPathAssertions
{

    /// <summary>
    ///     Then step: Asserts a JSONPath is resolvable on the content of a variable.
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    [Then("the JSONPath '(.*)' is valid on value of variable '(.*)'")]
    public void AssertJsonPathIsValid(string jPath, string sourceVariableName)
    {
        jsonPathDriver.AssertJsonPathReturnsAnyValue(jPath,sourceVariableName);
    }

    /// <summary>
    ///     Then step: Asserts a JSONPath is not resolvable on the content of a variable (the property does not exist).
    /// </summary>
    /// <param name="jPath">The JSONPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the source variable containing JSON.</param>
    [Then("the JSONPath '(.*)' is not valid on value of variable '(.*)'")]
    public void AssertJsonPathIsInvalid(string jPath, string sourceVariableName)
    {
        jsonPathDriver.AssertJsonPathDoesNotReturnAnyValue(jPath, sourceVariableName);
    }
}