using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.de
{
    [Binding]
    public class BasicVariableBindings(IBasicVariableLogic basicVariableLogic) : IBasicVariableBindings
    {
        [When("der Wert '(.*)' in der Variable '(.*)' abgelegt wird")]
        public void SetVariableManually(string value, string variableName)
        {
            basicVariableLogic.SetVariable(variableName,value);
        }

        [When("der folgende Wert in der Variable '(.*)' abgelegt wird:")]
        public void SetVariableManuallyMultiline(string variableName, string value)
        {
            basicVariableLogic.SetVariable(value,variableName);
        }
    }
}
