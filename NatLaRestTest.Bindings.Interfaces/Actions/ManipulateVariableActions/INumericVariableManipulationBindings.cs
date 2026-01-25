namespace NatLaRestTest.Bindings.Interfaces.Actions.ManipulateVariableActions;

public interface INumericVariableManipulationBindings
{

    public void Addition(string summand1, string summand2, string targetVariableName);
    public void Subtraction(string minuend, string subtrahend, string targetVariableName);
    public void Multiplication(string factor1, string factor2, string targetVariableName);
    public void Division(string dividend, string divisor, string targetVariableName);
}