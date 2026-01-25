using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to evaluate XPath expressions against XML stored in scenario variables
/// and store the selected result into another variable.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="XmlDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to get and set scenario variables.</param>
/// <param name="xPathService">Service used to evaluate XPath expressions on XML content.</param>
public class XmlDriver(IVariableService variableService, IXPathService xPathService) : IXmlDriver
{

    /// <summary>
    /// Evaluates an XPath expression against XML stored in the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the scenario variable that contains the XML to evaluate.</param>
    /// <param name="targetVariableName">The name of the scenario variable where the evaluated value will be stored.</param>
    public void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName)
    {
        var xml = variableService.GetVariable(sourceVariableName);
        Assert.IsNotNull(xml, $"Scenario variable '{sourceVariableName}' was not set or is null.");

        var value = xPathService.EvaluateXPath(xml, xPath);
        variableService.SetVariable(targetVariableName, value);
    }
}