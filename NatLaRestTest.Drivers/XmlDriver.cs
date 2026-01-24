using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to evaluate XPath expressions against XML stored in scenario variables
/// and store the selected result into another variable.
/// </summary>
public class XmlDriver : IXmlDriver
{
    private readonly IVariableService _variableService;
    private readonly IXPathService _xPathService;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlDriver"/> class.
    /// </summary>
    /// <param name="variableService">Service used to get and set scenario variables.</param>
    /// <param name="xPathService">Service used to evaluate XPath expressions on XML content.</param>
    public XmlDriver(IVariableService variableService, IXPathService xPathService)
    {
        _variableService = variableService;
        _xPathService = xPathService;
    }

    /// <summary>
    /// Evaluates an XPath expression against XML stored in the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the scenario variable that contains the XML to evaluate.</param>
    /// <param name="targetVariableName">The name of the scenario variable where the evaluated value will be stored.</param>
    public void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName)
    {
        var xml = _variableService.GetVariable(sourceVariableName);
        Assert.IsNotNull(xml, $"Scenario variable '{sourceVariableName}' was not set or is null.");

        var value = _xPathService.EvaluateXPath(xml, xPath);
        _variableService.SetVariable(targetVariableName, value);
    }
}