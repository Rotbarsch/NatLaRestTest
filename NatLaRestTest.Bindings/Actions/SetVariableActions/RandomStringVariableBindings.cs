using NatLaRestTest.Bindings.Interfaces.Actions.SetVariableActions;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Logic.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Actions.SetVariableActions;

/// <summary>
///     Step bindings for generating and storing random strings in scenario variables.
/// </summary>
[Binding]
public class RandomStringVariableBindings : IRandomStringVariableBindings
{
    private readonly IRandomizerLogic _randomizerLogic;

    /// <summary>
    ///     Step bindings for generating and storing random strings in scenario variables.
    /// </summary>
    public RandomStringVariableBindings(IRandomizerLogic randomizerLogic)
    {
        _randomizerLogic = randomizerLogic;
    }

    /// <summary>
    ///     When step: Generates a random string based on the specified type and stores it in the given variable.
    /// </summary>
    /// <param name="stringType">
    ///     The category/type of random string to generate. Supported values:
    ///     FirstName: A random first name.
    ///     LastName: A random last name.
    ///     FullName: A random full name.
    ///     UserName: A random internet username.
    ///     Email: A random email address.
    ///     PhoneNumber: A random phone number.
    ///     CompanyName: A random company name.
    ///     JobTitle: A random job title.
    ///     City: A random city name.
    ///     Country: A random country name.
    ///     StreetAddress: A random street address.
    ///     ZipCode: A random ZIP/postal code.
    ///     Url: A random internet URL.
    ///     Word: A random lorem word.
    ///     Sentence: A random lorem sentence.
    ///     Ipv4: A random IPv4 address.
    ///     Ipv6: A random IPv6 address.
    ///     Guid: A random GUID.
    /// </param>
    /// <param name="variableName">The variable name to store the generated string value.</param>
    [When("a random '(.*)' string is stored in variable '(.*)'")]
    public void SetRandomString(FakerStringType stringType, string variableName)
    {
        _randomizerLogic.SetRandomString(stringType, variableName);
    }
}