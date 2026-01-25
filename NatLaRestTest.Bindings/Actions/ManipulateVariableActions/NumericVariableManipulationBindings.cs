using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing numeric variables by applying arithmetic operations.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="NumericVariableManipulationBindings" /> class.
/// </remarks>
/// <param name="numericService">Driver component used to perform numeric operations.</param>
[Binding]
public class NumericVariableManipulationBindings(INumericService numericService) : INumericVariableManipulationBindings
{

    /// <summary>
    ///     When step: Adds the provided number to the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to add.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the number '(.*)' is added to the value of variable '(.*)'")]
    public void AddNumberToVariable(double number, string variableName)
    {
        numericService.AddNumberToVariable(number, variableName);
    }

    /// <summary>
    ///     When step: Multiplies the provided number with the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to multiply with.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the value of variable '(.*)' is multiplied with the number '(.*)'")]
    public void MultiplyNumberWithVariable(string variableName, double number)
    {
        numericService.MultiplyNumberWithVariable(number, variableName);
    }

    /// <summary>
    ///     When step (inverse of above): Divides the current numeric value stored in the specified variable by the provided
    ///     number (variable / number).
    /// </summary>
    /// <param name="variableName">The variable containing the dividend.</param>
    /// <param name="number">The divisor.</param>
    [When("the value of variable '(.*)' is divided by the number '(.*)'")]
    public void DivideVariableByNumber(string variableName, double number)
    {
        numericService.DivideVariableByNumber(variableName, number);
    }

    /// <summary>
    ///     When step: Subtracts the provided number from the current numeric value stored in the specified variable (variable
    ///     - number).
    /// </summary>
    /// <param name="number">The number to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the number '(.*)' is subtracted from the value of variable '(.*)'")]
    public void SubtractNumberFromVariable(double number, string variableName)
    {
        numericService.SubtractNumberFromVariable(number, variableName);
    }
}