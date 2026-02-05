using NatLaRestTest.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NatLaRestTest.Services;

/// <summary>
///     Service that evaluates JSONPath expressions against JSON strings and returns resolved values.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="JsonPathService" /> class.
/// </remarks>
/// <param name="loggingService">The logging Service used to write evaluation traces.</param>
public class JsonPathService(ITestOutputLoggingService loggingService) : IJsonPathService
{

    /// <inheritdoc />
    public string? GetValueFromJsonPath(string? inputJson, string jsonPathExpression)
    {
        Assert.IsNotNull(inputJson);

        var jToken = JToken.Parse(inputJson!);
        var token = jToken.SelectToken(jsonPathExpression);

        loggingService.WriteLine("JSONPath '{jsonPathExpression}' on '{inputJson}' returned: '{token}'", jsonPathExpression, inputJson!, token ?? "null");

        if (token is null || token.Type == JTokenType.Null) return null;
        return token.Type is JTokenType.Array or JTokenType.Object ? token.ToString() : token.Value<string>();
    }

    /// <inheritdoc />
    public bool JsonPathReturnsAnyValue(string? inputJson, string jsonPathExpression)
    {
        try
        {
            var jToken = JToken.Parse(inputJson!);

            if (jToken.Type is JTokenType.Array)
            {
                jToken.SelectTokens(jsonPathExpression, new JsonSelectSettings
                {
                    ErrorWhenNoMatch = true
                });
            }
            else
            {
                jToken.SelectToken(jsonPathExpression, new JsonSelectSettings
                {
                    ErrorWhenNoMatch = true
                });

            }

            return true;
        }
        catch (JsonException)
        {
            return false;
        }

    }
}