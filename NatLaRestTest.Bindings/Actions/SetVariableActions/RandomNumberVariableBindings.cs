using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Drivers.Interfaces;
using NUnit.Framework;
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
    /// <param name="minValueAsString">The inclusive lower bound of the random range.</param>
    /// <param name="maxValueAsString">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated integer value.</param>
    [When("a random integer between '(.*)' and '(.*)' is stored in variable '(.*)'")]
    public void SetRandomNumberInRange(string minValueAsString, string maxValueAsString, string variableName)
    {
        if (!int.TryParse(minValueAsString, out var minValue)) Assert.Fail($"{minValueAsString} is no valid integer.");
        if (!int.TryParse(maxValueAsString, out var maxValue)) Assert.Fail($"{maxValueAsString} is no valid integer.");
        randomizerDriver.SetRandomNumberInRange(minValue, maxValue, variableName);
    }

    /// <summary>
    ///     When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the
    ///     specified variable.
    /// </summary>
    /// <param name="minValueAsString">The inclusive lower bound of the random range.</param>
    /// <param name="maxValueAsString">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated double value.</param>
    [When("a random double between '(.*)' and '(.*)' is stored in variable '(.*)'")]
    public void SetRandomDoubleInRange(string minValueAsString, string maxValueAsString, string variableName)
    {
        if (!double.TryParse(minValueAsString, out var minValue)) Assert.Fail($"{minValueAsString} is no valid double.");
        if (!double.TryParse(maxValueAsString, out var maxValue)) Assert.Fail($"{maxValueAsString} is no valid double.");
        randomizerDriver.SetRandomDoubleInRange(minValue, maxValue, variableName);
    }
}