using System;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Logic;

public class ComparisonLogic(INumericDriver numericDriver, IBoolDriver boolDriver) : IComparisonLogic
{
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

            // Bool only
            case ComparisonOperation.BoolEquals:
                return CompareBool(comparisonValue, value);

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

    private bool CompareBool(string? expectedBooleanString, string? actualBooleanString)
    {
        if(!boolDriver.ParseBool(expectedBooleanString, out var expected)) Assert.Fail($"Cannot parse '{expectedBooleanString}' as bool");
        if(!boolDriver.ParseBool(actualBooleanString, out var actual)) Assert.Fail($"Cannot parse '{actualBooleanString}' as bool");

        return expected == actual;
    }

    private bool CompareNumeric(string? value, string? compareValue, ComparisonOperation comparisonOperation)
    {
        if (!numericDriver.ParseNumber(value, out var parsedValue))
            Assert.Fail($"'{value}' is not parsable as a number.");
        if (!numericDriver.ParseNumber(compareValue, out var compareParsedValue))
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