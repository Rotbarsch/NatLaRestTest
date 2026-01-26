using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;
using Reqnroll;
using DataTable = Reqnroll.DataTable;

namespace NatLaRestTest.Core;

/// <summary>
///     Provides a step argument transformation that resolves variable placeholders in the form $(variableName).
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="VariableNameTransformer" /> class.
/// </remarks>
/// <param name="variableService">The variable Service used to resolve placeholder values.</param>
[Binding]
public class VariableNameTransformer(IVariableService variableService)
{
    /// <summary>
    /// Gets all variables marked by $() in a DataTable and resolves them to their values.
    /// Supports nested placeholders by resolving innermost first.
    /// </summary>
    /// <param name="dataTable">Input datatable.</param>
    /// <returns>New DataTable with all variable instances resolved to their values.</returns>
    [StepArgumentTransformation]
    public DataTable ResolveVariablesInDataTable(DataTable dataTable)
    {
        var resultDt = new DataTable(dataTable.Header.ToArray());

        foreach (var r in dataTable.Rows)
        {
            resultDt.AddRow(r.Values.Select(ResolveVariable).ToArray());
        }

        return resultDt;
    }

    /// <summary>
    ///     Gets all variables marked by $() and resolves them to their values.
    ///     Supports nested placeholders by resolving innermost first.
    /// </summary>
    /// <param name="argument">The original step argument which may contain variable placeholders in the form $(variableName).</param>
    /// <returns>The argument string with all variable placeholders replaced by their resolved values.</returns>
    [StepArgumentTransformation]
    public string? ResolveVariable(string argument)
    {
        Assert.NotNull(argument);
        
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
                var value = variableService.GetVariable(variableName);
                return value ?? string.Empty;
            });

            safetyCounter++;
        }

        return updated;
    }
}