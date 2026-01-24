using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing basic assertions on scenario variables (null/not null).
/// </summary>
[Binding]
public class BasicVariableAssertions : IBasicVariableAssertions
{
    private readonly IBasicVariableDriver _basicVariableDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BasicVariableAssertions" /> class.
    /// </summary>
    /// <param name="basicVariableDriver">Driver component used to perform variable assertions.</param>
    public BasicVariableAssertions(IBasicVariableDriver basicVariableDriver)
    {
        _basicVariableDriver = basicVariableDriver;
    }

    /// <summary>
    ///     Then step: Asserts that the specified variable is null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is null")]
    public void AssertVariableIsNull(string variableName) =>
        _basicVariableDriver.AssertVariableIsNull(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable is not null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is not null")]
    public void AssertVariableIsNotNull(string variableName) =>
        _basicVariableDriver.AssertVariableIsNotNull(variableName);
}