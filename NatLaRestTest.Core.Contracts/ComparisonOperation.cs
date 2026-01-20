namespace NatLaRestTest.Core.Contracts;

/// <summary>
/// Specifies the type of comparison operation to perform when evaluating values.
/// Operations cover equality, null checks, relational comparisons and collection/string specific checks.
/// </summary>
/// <remarks>Use this enumeration to indicate the desired comparison logic in filtering, searching, or conditional
/// evaluation scenarios. The available operations include standard relational and equality comparisons, as well as null
/// checks.</remarks>
public enum ComparisonOperation
{
    /// <summary>
    /// Values are equal.
    /// </summary>
    Equals,

    /// <summary>
    /// Values are not equal.
    /// </summary>
    DoesNotEqual,

    /// <summary>
    /// Value is null.
    /// </summary>
    IsNull,

    /// <summary>
    /// Value is not null.
    /// </summary>
    IsNotNull,

    // numeric
    /// <summary>
    /// Left is greater than right.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Left is greater than or equal to right.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Left is less than right.
    /// </summary>
    LessThan,

    /// <summary>
    /// Left is less than or equal to right.
    /// </summary>
    LessThanOrEqual,
    
    // String only
    /// <summary>
    /// String is not empty and not null.
    /// </summary>
    IsNotEmpty,

    /// <summary>
    /// String is empty and not null.
    /// </summary>
    IsEmpty,

    // Collection only
    /// <summary>
    /// Collection has at least one element and is not null.
    /// </summary>
    HasElements,

    /// <summary>
    /// Collection has no elements and is not null.
    /// </summary>
    HasNoElements,
    
    /// <summary>
    /// Offer a comparison of boolean values.
    /// </summary>
    BoolEquals,
    
}