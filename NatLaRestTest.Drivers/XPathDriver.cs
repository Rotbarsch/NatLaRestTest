using System.Xml;
using NatLaRestTest.Drivers.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
///     Driver that evaluates XPath expressions against XML strings and logs the result.
/// </summary>
public class XPathDriver : IXPathDriver
{
    private readonly ITestOutputLoggingDriver _loggingDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="XPathDriver" /> class.
    /// </summary>
    /// <param name="loggingDriver">The logging driver used to write evaluation traces.</param>
    public XPathDriver(ITestOutputLoggingDriver loggingDriver)
    {
        _loggingDriver = loggingDriver;
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

        _loggingDriver.WriteLine($"XPath '{xPath}' on XML '{xml}' returned: '{value}'");

        return value;
    }
}