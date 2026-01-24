using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

public class BoolService : IBoolService
{
    public void AreBooleanEqual(bool expected, string? actual)
    {
        if(!ParseBool(actual, out var parsed)) Assert.Fail($"Cannot parse '{actual}' as bool.");
        Assert.AreEqual(expected, parsed);
    }

    public bool ParseBool(string? boolString, out bool parsed)
    {
        Assert.NotNull(boolString, "Null actual cannot be parsed as bool.");
        return bool.TryParse(boolString!, out parsed);
    }
}