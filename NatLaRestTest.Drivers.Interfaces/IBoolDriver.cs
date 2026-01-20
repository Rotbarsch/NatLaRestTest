namespace NatLaRestTest.Drivers.Interfaces;

public interface IBoolDriver
{
    void AreBooleanEqual(bool expected, string? actual);
    bool ParseBool(string? boolString, out bool parsed);
}