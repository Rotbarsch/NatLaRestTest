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
            // Equality
            ComparisonOperation.Equals => value == comparisonValue,
            ComparisonOperation.DoesNotEqual => value != comparisonValue,

            // Null checks
            ComparisonOperation.IsNull => value is null,
            ComparisonOperation.IsNotNull => value is not null,

            // Relational (numeric / DateTime)
            ComparisonOperation.LessThan
                or ComparisonOperation.LessThanOrEqual
                or ComparisonOperation.GreaterThan
                or ComparisonOperation.GreaterThanOrEqual => CompareTyped(value, comparisonValue, comparisonOperation),

            // String
            ComparisonOperation.IsEmpty => value?.Length == 0,
            ComparisonOperation.IsNotEmpty => !string.IsNullOrEmpty(value),

            // Collection
            ComparisonOperation.HasElements => value is not null && JArray.Parse(value).HasValues,
            ComparisonOperation.HasNoElements => value is not null && !JArray.Parse(value).HasValues,

            // Boolean
            ComparisonOperation.BoolEquals => CompareBool(comparisonValue, value),

            // JsonPath validity
            ComparisonOperation.JsonPathValid => value is not null && bool.Parse(value),
            ComparisonOperation.JsonPathInvalid => value is not null && !bool.Parse(value),

            _ => throw new InvalidOperationException($"Unsupported comparison operation '{comparisonOperation}'.")
        };
    }

    private bool CompareBool(string? expectedBooleanString, string? actualBooleanString)
    {
        if (!boolService.ParseBool(expectedBooleanString, out var expected)) Assert.Fail($"Cannot parse '{expectedBooleanString}' as bool");
        if (!boolService.ParseBool(actualBooleanString, out var actual)) Assert.Fail($"Cannot parse '{actualBooleanString}' as bool");

        return expected == actual;
    }

    private bool CompareTyped(string? value, string? compareValue, ComparisonOperation comparisonOperation)
    {
        if (numericService.ParseNumber(value, out var n1) && numericService.ParseNumber(compareValue, out var n2))
            return CompareNumbers(comparisonOperation, n1, n2);

        if (DateTime.TryParse(value, out var d1) && DateTime.TryParse(compareValue, out var d2))
            return CompareDateTimes(comparisonOperation, d1, d2);

        Assert.Fail($"'{value}' and/or '{compareValue}' are neither parsable as dates nor numbers.");
        return false;
    }

    private static bool CompareDateTimes(ComparisonOperation comparisonOperation, DateTime parsedValue, DateTime compareParsedValue)
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return comparisonOperation switch
        {
            ComparisonOperation.LessThan => parsedValue < compareParsedValue,
            ComparisonOperation.LessThanOrEqual => parsedValue <= compareParsedValue,
            ComparisonOperation.GreaterThan => parsedValue > compareParsedValue,
            ComparisonOperation.GreaterThanOrEqual => parsedValue >= compareParsedValue,
            _ => throw new InvalidOperationException(
                $"Unsupported comparison operation '{comparisonOperation}' for this comparison.")
        };
    }

    private static bool CompareNumbers(ComparisonOperation comparisonOperation, double parsedValue, double compareParsedValue)
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return comparisonOperation switch
        {
            ComparisonOperation.LessThan => parsedValue < compareParsedValue,
            ComparisonOperation.LessThanOrEqual => parsedValue <= compareParsedValue,
            ComparisonOperation.GreaterThan => parsedValue > compareParsedValue,
            ComparisonOperation.GreaterThanOrEqual => parsedValue >= compareParsedValue,
            _ => throw new InvalidOperationException(
                $"Unsupported comparison operation '{comparisonOperation}' for this comparison.")
        };
    }
}