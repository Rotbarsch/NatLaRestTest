using Reqnroll;

namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Declares step bindings for extracting values from XML using XPath and storing them in scenario variables.
/// </summary>
public interface IVariableXmlBindings
{
    /// <summary>
    /// When step: Evaluates the given XPath expression against the XML stored in a variable
    /// and stores the resulting node/attribute string value in the specified target variable.
    /// </summary>
    /// <param name="xPath">The XPath expression to evaluate.</param>
    /// <param name="sourceVariableName">The name of the variable containing XML to evaluate.</param>
    /// <param name="targetVariableName">The name of the variable where the extracted value will be stored.</param>
    [When("the result of XPath '(.*)' in the value of variable '(.*)' is stored in variable '(.*)'")]
    void SetVariableFromXPath(string xPath, string sourceVariableName, string targetVariableName);
}