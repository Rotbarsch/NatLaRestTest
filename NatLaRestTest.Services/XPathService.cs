using System.Xml;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that evaluates XPath expressions against XML strings and logs the result.
/// </summary>
public class XPathService : IXPathService
{
    private readonly ITestOutputLoggingService _loggingService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="XPathService" /> class.
    /// </summary>
    /// <param name="loggingService">The logging Service used to write evaluation traces.</param>
    public XPathService(ITestOutputLoggingService loggingService)
    {
        _loggingService = loggingService;
    }

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

        _loggingService.WriteLine("XPath '{xPath}' on XML '{xml}' returned: '{value}'",xPath,xml,value);

        return value;
    }
}