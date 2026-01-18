using NatLaRestTest.Core.Contracts;

namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides logic for generating random numbers and strings and storing them in variables.
/// </summary>
public interface IRandomizerLogic
{
    /// <summary>
    /// Generates a random integer in the specified range and stores it in a variable.
    /// </summary>
    void SetRandomNumberInRange(int minValue, int maxValue, string variableName);

    /// <summary>
    /// Generates a random double in the specified range and stores it in a variable.
    /// </summary>
    void SetRandomDoubleInRange(double minValue, double maxValue, string variableName);

    /// <summary>
    /// Generates a random string based on the selected <see cref="FakerStringType"/> and stores it in a variable.
    /// </summary>
    void SetRandomString(FakerStringType stringType, string variableName);
}