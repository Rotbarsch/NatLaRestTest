using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Logic.Interfaces;

public interface IComparisonLogic
{
    bool Compare(string? value, ComparisonOperation comparisonOperation, string? comparisonValue = null);
}