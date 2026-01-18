using System.Globalization;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Logic.Interfaces;

namespace NatLaRestTest.Logic;

public class RandomizerLogic : IRandomizerLogic
{
    private readonly IRandomDataDriver _randomDataDriver;
    private readonly IVariableDriver _variableDriver;

    public RandomizerLogic(IVariableDriver variableDriver, IRandomDataDriver randomDataDriver)
    {
        _variableDriver = variableDriver;
        _randomDataDriver = randomDataDriver;
    }

    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName)
    {
        _variableDriver.SetVariable(variableName, _randomDataDriver.GetIntegerInRange(minValue, maxValue).ToString());
    }

    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName)
    {
        var randomDouble = _randomDataDriver.GetDoubleInRange(minValue, maxValue)
            .ToString(CultureInfo.InvariantCulture);
        _variableDriver.SetVariable(variableName, randomDouble);
    }

    public void SetRandomString(FakerStringType stringType, string variableName)
    {
        var randomString = _randomDataDriver.GetRandomString(stringType);

        _variableDriver.SetVariable(variableName, randomString);
    }
}