namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Provides regular expression based assertions for variables.
/// </summary>
public interface IRegExDriver
{
    /// <summary>
    /// Asserts that the specified variable value matches the provided regular expression pattern.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="pattern">The regular expression pattern.</param>
    void AssertVariableMatchesRegex(string variableName, string pattern);
}