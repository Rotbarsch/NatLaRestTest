namespace NatLaRestTest.Bindings.Interfaces.Assertions;

public interface IRegExAssertions
{
    /// <summary>
    ///     Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The name of the variable whose value will be tested.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    void AssertVariableMatchesRegex(string variableName, string pattern);
}