namespace NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;

public interface IRandomNumberVariableBindings
{
    /// <summary>
    ///     When step: Generates a random integer within the inclusive lower/upper bounds and stores it in the specified
    ///     variable.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random range.</param>
    /// <param name="maxValue">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated integer value.</param>
    void SetRandomNumberInRange(string minValue, string maxValue, string variableName);

    /// <summary>
    ///     When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the
    ///     specified variable.
    /// </summary>
    /// <param name="minValueAsString">The inclusive lower bound of the random range.</param>
    /// <param name="maxValueAsString">The exclusive upper bound of the random range.</param>
    /// <param name="variableName">The variable name to store the generated double value.</param>
    void SetRandomDoubleInRange(string minValueAsString, string maxValueAsString, string variableName);
}