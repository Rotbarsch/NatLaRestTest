using NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.ManipulateVariableActions;

/// <summary>
///     Step bindings for executing artihmetics.
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
    /// Adds two numbers and stores the result in a variable.
    /// </summary>
    /// <param name="summand1">Summand.</param>
    /// <param name="summand2">Summand.</param>
    /// <param name="targetVariableName">Name of target variable to store sum in.</param>
    [When("the sum of '(.*)' plus '(.*)' is stored in variable '(.*)'")]
    public void Addition(string summand1, string summand2, string targetVariableName)
    {
        _numericService.Addition(summand1, summand2, targetVariableName);
    }

    /// <summary>
    /// Subtracts one number from another and stores the result in a variable.
    /// </summary>
    /// <param name="minuend">Minuend.</param>
    /// <param name="subtrahend">Subtrahend.</param>
    /// <param name="targetVariableName">Name of target variable to store difference in.</param>
    [When("the difference of '(.*)' minus '(.*)' is stored in variable '(.*)'")]
    public void Subtraction(string minuend, string subtrahend, string targetVariableName)
    {
        _numericService.Subtraction(minuend, subtrahend, targetVariableName);
    }

    /// <summary>
    /// Multiplies one number with another and stores the result in a variable.
    /// </summary>
    /// <param name="factor1">Factor.</param>
    /// <param name="factor2">Factor.</param>
    /// <param name="targetVariableName">Name of target variable to store product in.</param>
    [When("the product of '(.*)' multiplied by '(.*)' is stored in variable '(.*)'")]
    public void Multiplication(string factor1, string factor2, string targetVariableName)
    {
        _numericService.Multiplication(factor1, factor2, targetVariableName);
    }

    /// <summary>
    /// Divides one number by another and stores the result in a variable.
    /// </summary>
    /// <param name="dividend">Divided.</param>
    /// <param name="divisor">Dividend.</param>
    /// <param name="targetVariableName">Name of target variable to store quotient in.</param>
    [When("the quotient of '(.*)' divided by '(.*)' is stored in variable '(.*)'")]
    public void Division(string dividend, string divisor, string targetVariableName)
    {
        _numericService.Division(dividend, divisor, targetVariableName);
    }
}