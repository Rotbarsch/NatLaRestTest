namespace NatLaRestTest.Bindings.Drivers.Interfaces;

/// <summary>
/// Evaluates XPath expressions on XML content and returns the selected value.
/// </summary>
public interface IXPathDriver
{
    /// <summary>
    /// Evaluates an XPath expression on the provided XML string and returns the selected value.
    /// </summary>
    /// <param name="xml">The input XML string.</param>
    /// <param name="xPath">The XPath expression.</param>
    /// <returns>The selected value as string, or null if no node matches.</returns>
    string? EvaluateXPath(string? xml, string xPath);
}