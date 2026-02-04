using Bogus;
using NatLaRestTest.Core.Contracts;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that generates random numbers and strings using <see cref="Bogus" />.
/// </summary>
public class RandomDataService : IRandomDataService
{
    private static readonly Random _random = new();

    /// <inheritdoc />
    public double GetDoubleInRange(double minValue, double maxValue)
    {
        return _random.NextDouble() * (maxValue - minValue) + minValue;
    }

    /// <inheritdoc />
    public int GetIntegerInRange(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    /// <inheritdoc />
    public string GetRandomString(FakerStringType stringType)
    {
        var faker = new Faker();
        var randomString = "";
        switch (stringType)
        {
            case FakerStringType.FirstName:
                randomString = faker.Name.FirstName();
                break;
            case FakerStringType.LastName:
                randomString = faker.Name.LastName();
                break;
            case FakerStringType.FullName:
                randomString = faker.Name.FullName();
                break;
            case FakerStringType.UserName:
                randomString = faker.Internet.UserName();
                break;
            case FakerStringType.Email:
                randomString = faker.Internet.Email();
                break;
            case FakerStringType.PhoneNumber:
                randomString = faker.Phone.PhoneNumber();
                break;
            case FakerStringType.CompanyName:
                randomString = faker.Company.CompanyName();
                break;
            case FakerStringType.JobTitle:
                randomString = faker.Name.JobTitle();
                break;
            case FakerStringType.City:
                randomString = faker.Address.City();
                break;
            case FakerStringType.Country:
                randomString = faker.Address.Country();
                break;
            case FakerStringType.StreetAddress:
                randomString = faker.Address.StreetAddress();
                break;
            case FakerStringType.ZipCode:
                randomString = faker.Address.ZipCode();
                break;
            case FakerStringType.Url:
                randomString = faker.Internet.Url();
                break;
            case FakerStringType.Word:
                randomString = faker.Lorem.Word();
                break;
            case FakerStringType.Sentence:
                randomString = faker.Lorem.Sentence();
                break;
            case FakerStringType.Ipv4:
                randomString = faker.Internet.Ip();
                break;
            case FakerStringType.Ipv6:
                randomString = faker.Internet.Ipv6();
                break;
            case FakerStringType.Guid:
                randomString = faker.Random.Guid().ToString();
                break;
            default:
                Assert.Fail($"Unknown StringType: {stringType}");
                break;
        }

        return randomString;
    }
}