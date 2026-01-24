using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.de;

[Binding]
public class BasicVariableAssertions(IBasicVariableDriver basicVariableDriver) : IBasicVariableAssertions
{
    [Then("(?:ist )?der Wert der Variable '(.*)' null")]
    public void AssertVariableIsNull(string variableName)
    {
        basicVariableDriver.AssertVariableIsNull(variableName);
    }

    [Then("(?:ist )?der Wert der Variable '(.*)' nicht null")]
    public void AssertVariableIsNotNull(string variableName)
    {
        basicVariableDriver.AssertVariableIsNotNull(variableName);
    }
}