using NatLaRestTest.Bindings.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions;

/// <summary>
/// Step bindings for extracting values from XML using XPath and storing them in scenario variables.
/// The XML source is expected to be provided in the scenario variable named 'xml'.
/// </summary>
[Binding]
public class VariableXmlBindings
{
    private readonly IVariableDriver _variableDriver;
    private readonly IXPathDriver _xPathDriver;

    /// <summary>
    /// Step bindings for extracting values from XML using XPath and storing them in scenario variables.
    /// The XML source is expected to be provided in the scenario variable named 'xml'.
    /// </summary>
    public VariableXmlBindings(IVariableDriver variableDriver, IXPathDriver xPathDriver)
    {
        _variableDriver = variableDriver;
        _xPathDriver = xPathDriver;
    }

    /// <summary>
    /// When step: Evaluates the given XPath expression against the XML stored in scenario variable 'xml'
    /// and stores the resulting node/attribute string value in the specified target variable.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="targetVariableName">The name of the variable where the extracted value will be stored.</param>
    [When("when the value of XPath '(.*)' is stored in variable '(.*)'")]
    public void SetVariableFromXPath(string xPath, string targetVariableName)
    {
        var xml = _variableDriver.GetVariable("xml");
        Assert.IsNotNull(xml, "Scenario variable 'xml' was not set or is null.");

        var value= _xPathDriver.EvaluateXPath(xml, xPath);
        _variableDriver.SetVariable(targetVariableName, value);
    }
}