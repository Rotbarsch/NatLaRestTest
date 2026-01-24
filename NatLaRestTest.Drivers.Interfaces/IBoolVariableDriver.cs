namespace NatLaRestTest.Drivers.Interfaces;

/// <summary>
/// Provides assertions for boolean scenario variables.
/// </summary>
public interface IBoolVariableDriver
{
    /// <summary>
    /// Asserts that the specified variable represents the expected boolean value.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    /// <param name="boolean">The expected boolean value.</param>
    void AssertVariableIs(string variableName, bool boolean);
}