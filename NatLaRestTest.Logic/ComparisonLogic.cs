using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Logic.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

public class ComparisonLogic : IComparisonLogic
{
    private readonly INumericLogic _numericLogic;
    
    public ComparisonLogic(INumericLogic numericLogic)
    {
        _numericLogic = numericLogic;
    }

    public bool Compare(string? value, ComparisonOperation comparisonOperation, string? comparisonValue = null)
    {
        switch (comparisonOperation)
        {
            case ComparisonOperation.DoesNotEqual:
                return value != comparisonValue;
            case ComparisonOperation.Equals:
                return value == comparisonValue;
            case ComparisonOperation.IsNotNull:
                return value is not null;
            case ComparisonOperation.IsNull:
                return value is null;

            // Numeric
            case ComparisonOperation.LessThan:
            case ComparisonOperation.LessThanOrEqual:
            case ComparisonOperation.GreaterThan:
            case ComparisonOperation.GreaterThanOrEqual:
                return CompareNumeric(value, comparisonValue, comparisonOperation);

            // Collection only
            case ComparisonOperation.HasElements:
                return value is not null && JArray.Parse(value).HasValues;

            case ComparisonOperation.HasNoElements:
                return value is not null && !JArray.Parse(value).HasValues;

            // String only
            case ComparisonOperation.IsEmpty:
                return value is not null && string.IsNullOrEmpty(value) ;
            case ComparisonOperation.IsNotEmpty:
                return value is not null && !string.IsNullOrEmpty(value);
            default:
                throw new InvalidOperationException(
                    $"Unsupported comparison operation '{comparisonOperation}'.");
        }
    }

    private bool CompareNumeric(string? value, string? compareValue, ComparisonOperation comparisonOperation)
    {
        if (!_numericLogic.ParseNumber(value, out var parsedValue))
            Assert.Fail($"'{value}' is not parsable as a number.");
        if (!_numericLogic.ParseNumber(compareValue, out var compareParsedValue))
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