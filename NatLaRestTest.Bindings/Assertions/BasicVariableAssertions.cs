using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Assertions;

/// <summary>
///     Step bindings providing basic assertions on scenario variables (null/not null).
/// </summary>
[Binding]
public class BasicVariableAssertions : IBasicVariableAssertions
{
    private readonly IBasicVariableLogic _basicVariableLogic;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BasicVariableAssertions" /> class.
    /// </summary>
    /// <param name="basicVariableLogic">Logic component used to perform variable assertions.</param>
    public BasicVariableAssertions(IBasicVariableLogic basicVariableLogic)
    {
        _basicVariableLogic = basicVariableLogic;
    }

    /// <summary>
    ///     Then step: Asserts that the specified variable is null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is null")]
    public void AssertVariableIsNull(string variableName) =>
        _basicVariableLogic.AssertVariableIsNull(variableName);

    /// <summary>
    ///     Then step: Asserts that the specified variable is not null.
    /// </summary>
    /// <param name="variableName">The name of the variable to check.</param>
    [Then("the value of variable '(.*)' is not null")]
    public void AssertVariableIsNotNull(string variableName) =>
        _basicVariableLogic.AssertVariableIsNotNull(variableName);
}