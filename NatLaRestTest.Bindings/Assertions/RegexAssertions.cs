using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing regular expression based assertions on scenario variables.
/// </summary>
[Binding]
public class RegExAssertions : IRegExAssertions
{
    private readonly IRegExLogic _regExLogic;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RegExAssertions" /> class.
    /// </summary>
    /// <param name="regExLogic">Logic component used to perform regex assertions.</param>
    public RegExAssertions(IRegExLogic regExLogic)
    {
        _regExLogic = regExLogic;
    }

    /// <summary>
    ///     Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be tested.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    [Then("the value of variable '(.*)' matches the regex pattern '(.*)'")]
    public void AssertVariableMatchesRegex(string variableName, string pattern) =>
        _regExLogic.AssertVariableMatchesRegex(variableName, pattern);
}