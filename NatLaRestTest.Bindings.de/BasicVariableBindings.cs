using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace NatLaRestTest.Bindings.de;

[Binding]
public class BasicVariableBindings(IBasicVariableDriver basicVariableDriver) : IBasicVariableBindings
{
    [When("der Wert '(.*)' in der Variable '(.*)' abgelegt wird")]
    public void SetVariableManually(string value, string variableName)
    {
        basicVariableDriver.SetVariable(variableName,value);
    }

    [When("der folgende Wert in der Variable '(.*)' abgelegt wird:")]
    public void SetVariableManuallyMultiline(string variableName, string value)
    {
        basicVariableDriver.SetVariable(value,variableName);
    }
}