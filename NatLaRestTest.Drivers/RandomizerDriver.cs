using System.Globalization;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Drivers.Interfaces;
using NatLaRestTest.Services.Interfaces;

namespace NatLaRestTest.Drivers;

public class RandomizerDriver(IVariableService variableService, IRandomDataService randomDataService)
    : IRandomizerDriver
{
    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName)
    {
        variableService.SetVariable(variableName, randomDataService.GetIntegerInRange(minValue, maxValue).ToString());
    }

    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName)
    {
        var randomDouble = randomDataService.GetDoubleInRange(minValue, maxValue)
            .ToString(CultureInfo.InvariantCulture);
        variableService.SetVariable(variableName, randomDouble);
    }

    public void SetRandomString(FakerStringType stringType, string variableName)
    {
        var randomString = randomDataService.GetRandomString(stringType);

        variableService.SetVariable(variableName, randomString);
    }
}