using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.de;

[Binding]
public class BasicVariableAssertions(IBasicVariableLogic basicVariableLogic) : IBasicVariableAssertions
{
    [Then("(?:ist )?der Wert der Variable '(.*)' null")]
    public void AssertVariableIsNull(string variableName)
    {
        basicVariableLogic.AssertVariableIsNull(variableName);
    }

    [Then("(?:ist )?der Wert der Variable '(.*)' nicht null")]
    public void AssertVariableIsNotNull(string variableName)
    {
        basicVariableLogic.AssertVariableIsNotNull(variableName);
    }
}