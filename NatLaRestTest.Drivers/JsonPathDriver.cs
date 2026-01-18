using NatLaRestTest.Drivers.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Drivers;

/// <summary>
///     Driver that evaluates JSONPath expressions against JSON strings and returns resolved values.
/// </summary>
public class JsonPathDriver : IJsonPathDriver
{
    private readonly ITestOutputLoggingDriver _loggingDriver;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonPathDriver" /> class.
    /// </summary>
    /// <param name="loggingDriver">The logging driver used to write evaluation traces.</param>
    public JsonPathDriver(ITestOutputLoggingDriver loggingDriver)
    {
        _loggingDriver = loggingDriver;
    }

    /// <inheritdoc />
    public string? GetValueFromJsonPath(string? inputJson, string jsonPathExpression)
    {
        Assert.IsNotNull(inputJson);

        var jToken = JToken.Parse(inputJson!);
        var token = jToken.SelectToken(jsonPathExpression);

        _loggingDriver.WriteLine($"JSONPath '{jsonPathExpression}' on '{inputJson}' returned: '{token}'");

        return token?.ToString();
    }

    /// <inheritdoc />
    public bool JsonPathReturnsAnyValue(string? inputJson, string jsonPathExpression)
    {
        var jToken = JToken.Parse(inputJson!);
        var token = jToken.SelectToken(jsonPathExpression);

        return token is not null;
    }
}