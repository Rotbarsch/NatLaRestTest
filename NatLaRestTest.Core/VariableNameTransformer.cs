using System.Text.RegularExpressions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Core;

/// <summary>
///     Provides a step argument transformation that resolves variable placeholders in the form $(variableName).
/// </summary>
[Binding]
public class VariableNameTransformer
{
    private readonly IVariableService _variableService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="VariableNameTransformer" /> class.
    /// </summary>
    /// <param name="variableService">The variable Service used to resolve placeholder values.</param>
    public VariableNameTransformer(IVariableService variableService)
    {
        _variableService = variableService;
    }

    /// <summary>
    ///     Gets all variables marked by $() and resolves them to their values.
    ///     Supports nested placeholders by resolving innermost first.
    /// </summary>
    /// <param name="argument">The original step argument which may contain variable placeholders in the form $(variableName).</param>
    /// <returns>The argument string with all variable placeholders replaced by their resolved values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when argument is null.</exception>
    [StepArgumentTransformation]
    public string? ResolveVariable(string argument)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(nameof(argument));
        }

        // Match innermost placeholders only (no nested '(' or ')') in the variable name
        var pattern = "\\$\\(([^\\(\\)]+)\\)";
        var updated = argument;
        var safetyCounter = 0;

        // Resolve recursively until no more placeholders are found or safety limit reached
        while (Regex.IsMatch(updated, pattern) && safetyCounter < 100)
        {
            updated = Regex.Replace(updated, pattern, match =>
            {
                var variableName = match.Groups[1].Value;
                var value = _variableService.GetVariable(variableName);
                return value ?? string.Empty;
            });

            safetyCounter++;
        }

        return updated;
    }
}