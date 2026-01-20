namespace NatLaRestTest.Bindings.Interfaces.Assertions;

/// <summary>
/// Defines step assertion methods for boolean scenario variables.
/// </summary>
public interface IBoolVariableAssertions
{
    /// <summary>
    /// Then step: Asserts that the specified variable is true.
    /// Example usage: Then the value of variable 'isAvailable' is true
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    void AssertVariableIsTrue(string variableName);

    /// <summary>
    /// Then step: Asserts that the specified variable is false.
    /// Example usage: Then the value of variable 'featureEnabled' is false
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    void AssertVariableIsFalse(string variableName);
}