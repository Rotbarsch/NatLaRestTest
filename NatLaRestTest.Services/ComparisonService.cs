using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Services;

public class ComparisonService(INumericService numericService, IBoolService boolService) : IComparisonService
{
    public bool Compare(string? value, ComparisonOperation comparisonOperation, string? comparisonValue = null)
    {
        return comparisonOperation switch
        {
            ComparisonOperation.DoesNotEqual => value != comparisonValue,
            ComparisonOperation.Equals => value == comparisonValue,
            ComparisonOperation.IsNotNull => value is not null,
            ComparisonOperation.IsNull => value is null,
            // Numeric
            ComparisonOperation.LessThan or ComparisonOperation.LessThanOrEqual or ComparisonOperation.GreaterThan
                or ComparisonOperation.GreaterThanOrEqual =>
                CompareNumeric(value, comparisonValue, comparisonOperation),
            // Collection only
            ComparisonOperation.HasElements => value is not null && JArray.Parse(value).HasValues,
            ComparisonOperation.HasNoElements => value is not null && !JArray.Parse(value).HasValues,
            // Bool only
            ComparisonOperation.BoolEquals => CompareBool(comparisonValue, value),
            // String only
            ComparisonOperation.IsEmpty => value is not null && string.IsNullOrEmpty(value),
            ComparisonOperation.IsNotEmpty => value is not null && !string.IsNullOrEmpty(value),
            _ => throw new InvalidOperationException($"Unsupported comparison operation '{comparisonOperation}'.")
        };
    }

    private bool CompareBool(string? expectedBooleanString, string? actualBooleanString)
    {
        if(!boolService.ParseBool(expectedBooleanString, out var expected)) Assert.Fail($"Cannot parse '{expectedBooleanString}' as bool");
        if(!boolService.ParseBool(actualBooleanString, out var actual)) Assert.Fail($"Cannot parse '{actualBooleanString}' as bool");

        return expected == actual;
    }

    private bool CompareNumeric(string? value, string? compareValue, ComparisonOperation comparisonOperation)
    {
        if (!numericService.ParseNumber(value, out var parsedValue))
            Assert.Fail($"'{value}' is not parsable as a number.");
        if (!numericService.ParseNumber(compareValue, out var compareParsedValue))
            Assert.Fail($"'{compareValue}' is not parsable as a number.");

        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        // We only handle numeric comparison operations here
        return comparisonOperation switch
        {
            ComparisonOperation.LessThan => parsedValue < compareParsedValue,
            ComparisonOperation.LessThanOrEqual => parsedValue <= compareParsedValue,
            ComparisonOperation.GreaterThan => parsedValue > compareParsedValue,
            ComparisonOperation.GreaterThanOrEqual => parsedValue >= compareParsedValue,
            _ => throw new InvalidOperationException(
                $"Unsupported comparison operation '{comparisonOperation}' for numeric comparison.")
        };
    }
}