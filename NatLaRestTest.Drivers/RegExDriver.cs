using System.Text.RegularExpressions;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to assert that a variable's value matches a given regular expression pattern.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RegExDriver"/> class.
/// </remarks>
/// <param name="variableService">Service used to access scenario variables.</param>
public class RegExDriver(IVariableService variableService) : IRegExDriver
{

    /// <summary>
    /// Asserts that the specified variable's value matches the provided regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="variableName">Name of the variable whose value will be validated.</param>
    /// <param name="pattern">Regular expression pattern to match against.</param>
    /// <exception cref="Exception">Thrown when the variable is null or does not match the pattern.</exception>
    public void AssertVariableMatchesRegex(string variableName, string pattern)
    {
        if (!IsRegexMatch(variableName,pattern))
        {
            Assert.Fail(
                $"Variable '{variableName}' does not match the regex pattern '{pattern}'.");
        }
    }

    public void AssertVariableDoesNotMatchRegex(string variableName, string pattern)
    {
        if(IsRegexMatch(variableName, pattern))
        {
            Assert.Fail(
                $"Variable '{variableName}' does not match the regex pattern '{pattern}'.");
        }
    }

    private bool IsRegexMatch(string variableName, string pattern)
    {
        var value = variableService.GetVariable(variableName);
        if (value == null)
        {
            Assert.Fail($"Variable '{variableName}' is null.");
        }

        return Regex.IsMatch(value!, pattern);
    }
}