namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides XPath-based operations on XML values stored in variables.
/// </summary>
public interface IXmlLogic
{
    /// <summary>
    /// Evaluates an XPath expression against the source variable and stores the result in the target variable.
    /// </summary>
    /// <param name="xPath">XPath expression.</param>
    /// <param name="sourceVariableName">Variable containing the XML source.</param>
    /// <param name="targetVariableName">Variable to store the evaluation result.</param>
    void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName);
}