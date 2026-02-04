using NatLaRestTest.Bindings.Interfaces.Assertions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable S2325 // Unused private types or members should be removed

namespace NatLaRestTest.Bindings.de;

[Binding]
public class StringVariableAssertions(IStringDriver stringDriver) : IStringVariableAssertions
{
    public void StringVariableLengthIsMoreThan(string variableName, int length)
    {
        throw new NotImplementedException();
    }

    public void StringVariableLengthIsLessThan(string variableName, int length)
    {
        throw new NotImplementedException();
    }

    public void StringVariableLengthIs(string variableName, int length)
    {
        throw new NotImplementedException();
    }

    public void StringVariableIsNotEmpty(string variableName)
    {
        throw new NotImplementedException();
    }

    public void StringVariableIsEmpty(string variableName)
    {
        throw new NotImplementedException();
    }

    public void StringVariableStartsWith(string variableName, string prefix)
    {
        throw new NotImplementedException();
    }

    public void StringVariableEndsWith(string variableName, string suffix)
    {
        throw new NotImplementedException();
    }

    public void StringVariableNotStartsWith(string variableName, string prefix)
    {
        throw new NotImplementedException();
    }

    public void StringVariableNotEndsWith(string variableName, string suffix)
    {
        throw new NotImplementedException();
    }

    public void StringVariableContains(string variableName, string substring)
    {
        throw new NotImplementedException();
    }

    public void StringVariableNotContains(string variableName, string substring)
    {
        throw new NotImplementedException();
    }

    [Then("ist der Wert der Variable '(.*)' gleich '(.*)'")]
    public void StringVariableEquals(string variableName, string comparison)
    {
        stringDriver.StringVariableEquals(variableName, comparison);
    }

    public void StringVariableNotEquals(string variableName, string comparison)
    {
        throw new NotImplementedException();
    }
}