using System.Globalization;
using NatLaRestTest.Bindings.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Bindings.Actions.SetVariableActions;

/// <summary>
/// Step bindings for generating and storing random numeric values in scenario variables.
/// </summary>
[Binding]
public class RandomNumberVariableBindings
{
    private readonly IVariableDriver _variableDriver;
    private readonly IRandomDataDriver _randomDataDriver;

    /// <summary>
    /// Step bindings for generating and storing random numeric values in scenario variables.
    /// </summary>
    public RandomNumberVariableBindings(IVariableDriver variableDriver, IRandomDataDriver randomDataDriver)
    {
        _variableDriver = variableDriver;
        _randomDataDriver = randomDataDriver;
    }
    
    /// <summary>
    /// When step: Generates a random integer within the inclusive lower/upper bounds and stores it in the specified variable.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random range.</param>
    /// <param name="maxValue">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated integer value.</param>
    [When("a random integer between (.*) and (.*) is stored in variable '(.*)'")]
    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName)
    {
        _variableDriver.SetVariable(variableName, _randomDataDriver.GetIntegerInRange(minValue,maxValue).ToString());
    }

    /// <summary>
    /// When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the specified variable.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random range.</param>
    /// <param name="maxValue">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated double value.</param>
    [When("a random double between (.*) and (.*) is stored in variable '(.*)'")]
    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName)
    {
        var randomDouble = _randomDataDriver.GetDoubleInRange(minValue, maxValue).ToString(CultureInfo.InvariantCulture);
        _variableDriver.SetVariable(variableName, randomDouble);
    }
}