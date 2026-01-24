using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that evaluates JSONPath expressions against JSON strings and returns resolved values.
/// </summary>
public class JsonPathService : IJsonPathService
{
    private readonly ITestOutputLoggingService _loggingService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonPathService" /> class.
    /// </summary>
    /// <param name="loggingService">The logging Service used to write evaluation traces.</param>
    public JsonPathService(ITestOutputLoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    /// <inheritdoc />
    public string? GetValueFromJsonPath(string? inputJson, string jsonPathExpression)
    {
        Assert.IsNotNull(inputJson);

        var jToken = JToken.Parse(inputJson!);
        var token = jToken.SelectToken(jsonPathExpression);

        _loggingService.WriteLine("JSONPath '{jsonPathExpression}' on '{inputJson}' returned: '{token}'",jsonPathExpression,inputJson,token);

        if (token is null) return null;
        return token.Type is JTokenType.Array or JTokenType.Object ? token.ToString() : token.Value<string>();
    }

    /// <inheritdoc />
    public bool JsonPathReturnsAnyValue(string? inputJson, string jsonPathExpression)
    {
        var jToken = JToken.Parse(inputJson!);
        var token = jToken.SelectToken(jsonPathExpression);

        return token is not null;
    }
}