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
        return variableService.ResolvePlaceHolderString(argument);
    }
}