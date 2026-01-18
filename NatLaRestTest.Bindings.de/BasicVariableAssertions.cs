using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.de;

[Binding]
public class BasicVariableAssertions : IBasicVariableAssertions
{
    private readonly IBasicVariableLogic _basicVariableLogic;

    public BasicVariableAssertions(IBasicVariableLogic basicVariableLogic)
    {
        _basicVariableLogic = basicVariableLogic;
    }

    [Then("(?:ist )?der Wert der Variable '(.*)' null")]
    public void AssertVariableIsNull(string variableName)
    {
        _basicVariableLogic.AssertVariableIsNull(variableName);
    }

    [Then("(?:ist )?der Wert der Variable '(.*)' nicht null")]
    public void AssertVariableIsNotNull(string variableName)
    {
        _basicVariableLogic.AssertVariableIsNotNull(variableName);
    }
}