using NatLaRestTest.Bindings.Interfaces.Actions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions;

/// <summary>
/// Step bindings for extracting values from XML using XPath and storing them in scenario variables.
/// </summary>
[Binding]
public class VariableXmlBindings : IVariableXmlBindings
{
    private readonly IXmlDriver _xmlDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableXmlBindings"/> class.
    /// </summary>
    /// <param name="xmlDriver">Driver component used to evaluate XPath and set variables.</param>
    public VariableXmlBindings(IXmlDriver xmlDriver)
    {
        _xmlDriver = xmlDriver;
    }

    /// <summary>
    /// When step: Evaluates the given XPath expression against XML stored in <paramref name="sourceVariableName"/>
    /// and stores the resulting node/attribute string value in <paramref name="targetVariableName"/>.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the variable containing XML to evaluate.</param>
    /// <param name="targetVariableName">The name of the variable where the extracted value will be stored.</param>
    [When("the result of XPath '(.*)' in the value of variable '(.*)' is stored in variable '(.*)'")]
    public void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName)
    {
        _xmlDriver.SetVariableFromXPath(xPath, sourceVariableName, targetVariableName);
    }
}