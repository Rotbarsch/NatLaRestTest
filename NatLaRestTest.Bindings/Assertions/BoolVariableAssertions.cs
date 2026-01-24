using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
/// Step bindings providing assertions for boolean scenario variables.
/// </summary>
/// <param name="boolVariableDriver">Driver component used to perform boolean variable assertions.</param>
[Binding]
public class BoolVariableAssertions(IBoolVariableDriver boolVariableDriver) : IBoolVariableAssertions
{
    /// <summary>
    /// Then step: Asserts that the specified variable is true.
    /// Example usage: Then the value of variable 'isAvailable' is true
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is true")]
    public void AssertVariableIsTrue(string variableName)
    {
        boolVariableDriver.AssertVariableIs(variableName, true);
    }

    /// <summary>
    /// Then step: Asserts that the specified variable is false.
    /// Example usage: Then the value of variable 'featureEnabled' is false
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is false")]
    public void AssertVariableIsFalse(string variableName)
    {
        boolVariableDriver.AssertVariableIs(variableName, false);
    }
}