using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Services.Interfaces;

public interface IComparisonService
{
    bool Compare(string? value, ComparisonOperation comparisonOperation, string? comparisonValue = null);
}