using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing regular expression based assertions on scenario variables.
/// </summary>
[Binding]
public class RegExAssertions : IRegExAssertions
{
    private readonly IRegExDriver _regExDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RegExAssertions" /> class.
    /// </summary>
    /// <param name="regExDriver">Driver component used to perform regex assertions.</param>
    public RegExAssertions(IRegExDriver regExDriver)
    {
        _regExDriver = regExDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be tested.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    [Then("the value of variable '(.*)' matches the regex pattern '(.*)'")]
    public void AssertVariableMatchesRegex(string variableName, string pattern) =>
        _regExDriver.AssertVariableMatchesRegex(variableName, pattern);

    /// <summary>
    /// Then step: Asserts that the value of the specified variable does not match the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be tested.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    [Then("the value of variable '(.*)' does not match the regex pattern '(.*)'")]
    public void AssertVariableDoesNotMatchRegex(string variableName, string pattern) =>
        _regExDriver.AssertVariableDoesNotMatchRegex(variableName, pattern);
}