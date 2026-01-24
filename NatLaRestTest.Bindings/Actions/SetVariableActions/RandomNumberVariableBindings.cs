using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Drivers.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings for generating and storing random numeric values in scenario variables.
/// </summary>
[Binding]
public class RandomNumberVariableBindings(IRandomizerDriver randomizerDriver) : IRandomNumberVariableBindings
{
    /// <summary>
    ///     When step: Generates a random integer within the inclusive lower/upper bounds and stores it in the specified
    ///     variable.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random range.</param>
    /// <param name="maxValue">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated integer value.</param>
    [When("a random integer between (.*) and (.*) is stored in variable '(.*)'")]
    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName) =>
        randomizerDriver.SetRandomNumberInRange(minValue, maxValue, variableName);

    /// <summary>
    ///     When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the
    ///     specified variable.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random range.</param>
    /// <param name="maxValue">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated double value.</param>
    [When("a random double between (.*) and (.*) is stored in variable '(.*)'")]
    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName) =>
        randomizerDriver.SetRandomDoubleInRange(minValue, maxValue, variableName);
}