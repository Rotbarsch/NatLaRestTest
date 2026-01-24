using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for manipulating existing numeric variables by applying arithmetic operations.
/// </summary>
[Binding]
public class NumericVariableManipulationBindings : INumericVariableManipulationBindings
{
    private readonly INumericService _numericService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="NumericVariableManipulationBindings" /> class.
    /// </summary>
    /// <param name="numericService">Driver component used to perform numeric operations.</param>
    public NumericVariableManipulationBindings(INumericService numericService)
    {
        _numericService = numericService;
    }

    /// <summary>
    ///     When step: Adds the provided number to the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to add.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the number '(.*)' is added to the value of variable '(.*)'")]
    public void AddNumberToVariable(double number, string variableName)
    {
        _numericService.AddNumberToVariable(number, variableName);
    }

    /// <summary>
    ///     When step: Multiplies the provided number with the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to multiply with.</param>
    /// <param name="variableName">The target variable name.</param>
    [When("the number '(.*)' is multiplied with the value of variable '(.*)'")]
    public void MultiplyNumberWithVariable(double number, string variableName)
    {
        _numericService.MultiplyNumberWithVariable(number, variableName);
    }

    /// <summary>
    ///     When step: Divides the provided number by the current numeric value stored in the specified variable (number /
    ///     variable).
    /// </summary>
    /// <param name="number">The dividend.</param>
    /// <param name="variableName">The variable containing the divisor.</param>
    [When("the number '(.*)' is divided by the value of variable '(.*)'")]
    public void DivideNumberByVariable(double number, string variableName)
    {
        _numericService.DivideNumberByVariable(number, variableName);
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
        _numericService.DivideVariableByNumber(variableName, number);
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
        _numericService.SubtractNumberFromVariable(number, variableName);
    }

    /// <summary>
    ///     When step (inverse of above): Subtracts the current numeric value stored in the specified variable from the
    ///     provided number (number - variable).
    /// </summary>
    /// <param name="variableName">The variable containing the subtrahend.</param>
    /// <param name="number">The minuend.</param>
    [When("the value of variable '(.*)' is subtracted from the number '(.*)'")]
    public void SubtractVariableFromNumber(string variableName, double number)
    {
        _numericService.SubtractVariableFromNumber(variableName, number);
    }
}