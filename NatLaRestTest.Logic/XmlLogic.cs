using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

/// <summary>
/// Provides logic to evaluate XPath expressions against XML stored in scenario variables
/// and store the selected result into another variable.
/// </summary>
public class XmlLogic : IXmlLogic
{
    private readonly IVariableDriver _variableDriver;
    private readonly IXPathDriver _xPathDriver;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlLogic"/> class.
    /// </summary>
    /// <param name="variableDriver">Driver used to get and set scenario variables.</param>
    /// <param name="xPathDriver">Driver used to evaluate XPath expressions on XML content.</param>
    public XmlLogic(IVariableDriver variableDriver, IXPathDriver xPathDriver)
    {
        _variableDriver = variableDriver;
        _xPathDriver = xPathDriver;
    }

    /// <summary>
    /// Evaluates an XPath expression against XML stored in the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the scenario variable that contains the XML to evaluate.</param>
    /// <param name="targetVariableName">The name of the scenario variable where the evaluated value will be stored.</param>
    public void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName)
    {
        var xml = _variableDriver.GetVariable(sourceVariableName);
        Assert.IsNotNull(xml, $"Scenario variable '{sourceVariableName}' was not set or is null.");

        var value = _xPathDriver.EvaluateXPath(xml, xPath);
        _variableDriver.SetVariable(targetVariableName, value);
    }
}