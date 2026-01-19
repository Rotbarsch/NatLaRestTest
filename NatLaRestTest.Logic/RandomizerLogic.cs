using System.Globalization;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;

namespace NatLaRestTest.Logic;

public class RandomizerLogic(IVariableDriver variableDriver, IRandomDataDriver randomDataDriver)
    : IRandomizerLogic
{
    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName)
    {
        variableDriver.SetVariable(variableName, randomDataDriver.GetIntegerInRange(minValue, maxValue).ToString());
    }

    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName)
    {
        var randomDouble = randomDataDriver.GetDoubleInRange(minValue, maxValue)
            .ToString(CultureInfo.InvariantCulture);
        variableDriver.SetVariable(variableName, randomDouble);
    }

    public void SetRandomString(FakerStringType stringType, string variableName)
    {
        var randomString = randomDataDriver.GetRandomString(stringType);

        variableDriver.SetVariable(variableName, randomString);
    }
}