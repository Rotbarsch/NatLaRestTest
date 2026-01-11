using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Assertions;

/// <summary>
/// Step bindings providing regular expression based assertions on scenario variables.
/// </summary>
[Binding]
public class RegExAssertions
{
    private readonly IVariableDriver _variableDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegExAssertions"/> class.
    /// </summary>
    /// <param name="variableDriver">The variable driver dependency.</param>
    public RegExAssertions(IVariableDriver variableDriver)
    {
        _variableDriver = variableDriver;
    }

    /// <summary>
    /// Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be tested.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    [Then("the value of variable '(.*)' matches the regex pattern '(.*)'")]
    public void AssertVariableMatchesRegex(string variableName, string pattern)
    {
        var value = _variableDriver.GetVariable(variableName);
        if (value == null)
        {
            throw new Exception($"Variable '{variableName}' is null.");
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
        {
            throw new Exception($"Variable '{variableName}' with value '{value}' does not match the regex pattern '{pattern}'.");
        }
    }
}