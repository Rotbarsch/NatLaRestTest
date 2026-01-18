namespace NatLaRestTest.Logic.Interfaces;

/// <summary>
/// Provides string manipulation operations and assertions on variables storing strings.
/// </summary>
public interface IStringLogic
{
    /// <summary>Appends a value to the end of the string variable.</summary>
    void AppendStringToVariable(string valueToAppend, string variableName);

    /// <summary>Prepends a value to the beginning of the string variable.</summary>
    void PrependStringToVariable(string valueToPrepend, string variableName);

    /// <summary>Replaces occurrences of a value in the string variable.</summary>
    void ReplaceStringInVariable(string oldValue, string newValue, string variableName);

    /// <summary>Asserts the string variable length is greater than the specified length.</summary>
    void StringVariableLengthIsMoreThan(string variableName, int length);

    /// <summary>Asserts the string variable length is less than the specified length.</summary>
    void StringVariableLengthIsLessThan(string variableName, int length);

    /// <summary>Asserts the string variable length equals the specified length.</summary>
    void StringVariableLengthIs(string variableName, int length);

    /// <summary>Asserts the string variable is not empty.</summary>
    void StringVariableIsNotEmpty(string variableName);

    /// <summary>Asserts the string variable is empty.</summary>
    void StringVariableIsEmpty(string variableName);

    /// <summary>Asserts the string variable starts with the specified prefix.</summary>
    void StringVariableStartsWith(string variableName, string prefix);

    /// <summary>Asserts the string variable ends with the specified suffix.</summary>
    void StringVariableEndsWith(string variableName, string suffix);

    /// <summary>Asserts the string variable does not start with the specified prefix.</summary>
    void StringVariableNotStartsWith(string variableName, string prefix);

    /// <summary>Asserts the string variable does not end with the specified suffix.</summary>
    void StringVariableNotEndsWith(string variableName, string suffix);

    /// <summary>Asserts the string variable contains the specified substring.</summary>
    void StringVariableContains(string variableName, string substring);

    /// <summary>Asserts the string variable does not contain the specified substring.</summary>
    void StringVariableNotContains(string variableName, string substring);

    /// <summary>Asserts equality of the string variable and comparison value.</summary>
    void StringVariableEquals(string variableName, string comparison);

    /// <summary>Asserts inequality of the string variable and comparison value.</summary>
    void StringVariableNotEquals(string variableName, string comparison);

    /// <summary>Stores the substring of <paramref name="input"/> into the target variable.</summary>
    void GetSubString(int startIndex, int length, string input, string targetVariableName);

    /// <summary>Stores the length of <paramref name="input"/> into the target variable.</summary>
    void GetStringLength(string input, string targetVariableName);
}