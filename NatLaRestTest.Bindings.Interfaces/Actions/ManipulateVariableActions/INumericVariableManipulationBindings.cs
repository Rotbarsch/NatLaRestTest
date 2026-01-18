namespace NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;

public interface INumericVariableManipulationBindings
{
    /// <summary>
    ///     When step: Adds the provided number to the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to add.</param>
    /// <param name="variableName">The target variable name.</param>
    void AddNumberToVariable(double number, string variableName);

    /// <summary>
    ///     When step: Multiplies the provided number with the current numeric value stored in the specified variable.
    /// </summary>
    /// <param name="number">The number to multiply with.</param>
    /// <param name="variableName">The target variable name.</param>
    void MultiplyNumberWithVariable(double number, string variableName);

    /// <summary>
    ///     When step: Divides the provided number by the current numeric value stored in the specified variable (number /
    ///     variable).
    /// </summary>
    /// <param name="number">The dividend.</param>
    /// <param name="variableName">The variable containing the divisor.</param>
    void DivideNumberByVariable(double number, string variableName);

    /// <summary>
    ///     When step (inverse of above): Divides the current numeric value stored in the specified variable by the provided
    ///     number (variable / number).
    /// </summary>
    /// <param name="variableName">The variable containing the dividend.</param>
    /// <param name="number">The divisor.</param>
    void DivideVariableByNumber(string variableName, double number);

    /// <summary>
    ///     When step: Subtracts the provided number from the current numeric value stored in the specified variable (variable
    ///     - number).
    /// </summary>
    /// <param name="number">The number to subtract.</param>
    /// <param name="variableName">The target variable name.</param>
    void SubtractNumberFromVariable(double number, string variableName);

    /// <summary>
    ///     When step (inverse of above): Subtracts the current numeric value stored in the specified variable from the
    ///     provided number (number - variable).
    /// </summary>
    /// <param name="variableName">The variable containing the subtrahend.</param>
    /// <param name="number">The minuend.</param>
    void SubtractVariableFromNumber(string variableName, double number);
}