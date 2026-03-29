using System.Text.Json;

namespace NatLaRestTest.Services.Helpers.HttpMessageContentBeautifier;

internal class JsonContentStringBeautifier: IContentTypeSpecificContentStringBeautifier
{
    private static readonly JsonSerializerOptions IndentedJson = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public string Beautify(string content)
    {
        var jDoc = JsonDocument.Parse(content);
        return JsonSerializer.Serialize(jDoc, IndentedJson);
    }
}