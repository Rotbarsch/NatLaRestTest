namespace NatLaRestTest.Bindings.Interfaces.Assertions;

/// <summary>
/// Declares step bindings for basic assertions on scenario variables (null/not null).
/// </summary>
public interface IBasicVariableAssertions
{
    /// <summary>
    ///     Then step: Asserts that the specified variable is null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    void AssertVariableIsNull(string variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable is not null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    void AssertVariableIsNotNull(string variableName);
}