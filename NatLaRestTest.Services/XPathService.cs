using System.Xml;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that evaluates XPath expressions against XML strings and logs the result.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="XPathService" /> class.
/// </remarks>
/// <param name="loggingService">The logging Service used to write evaluation traces.</param>
public class XPathService(ITestOutputLoggingService loggingService) : IXPathService
{

    /// <inheritdoc />
    public string? EvaluateXPath(string? xml, string xPath)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml!);
        var node = doc.SelectSingleNode(xPath);

        var value = node switch
        {
            null => null,
            XmlAttribute attr => attr.Value,
            _ => node.InnerText
        };

        loggingService.WriteLine("XPath '{xPath}' on XML '{xml}' returned: '{value}'", xPath, xml!, value ?? "null");

        return value;
    }
}