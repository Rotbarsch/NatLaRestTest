using System.Text.RegularExpressions;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

/// <summary>
/// Provides Driver to assert that a variable's value matches a given regular expression pattern.
/// </summary>
public class RegExDriver : IRegExDriver
{
    private readonly IVariableService _variableService;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegExDriver"/> class.
    /// </summary>
    /// <param name="variableService">Service used to access scenario variables.</param>
    public RegExDriver(IVariableService variableService)
    {
        _variableService = variableService;
    }

    /// <summary>
    /// Asserts that the specified variable's value matches the provided regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="variableName">Name of the variable whose value will be validated.</param>
    /// <param name="pattern">Regular expression pattern to match against.</param>
    /// <exception cref="Exception">Thrown when the variable is null or does not match the pattern.</exception>
    public void AssertVariableMatchesRegex(string variableName, string pattern)
    {
        var value = _variableService.GetVariable(variableName);
        if (value == null)
        {
            throw new Exception($"Variable '{variableName}' is null.");
        }

        if (!Regex.IsMatch(value, pattern))
        {
            throw new Exception(
                $"Variable '{variableName}' with value '{value}' does not match the regex pattern '{pattern}'.");
        }
    }
}