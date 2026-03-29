using System.Xml.Linq;

namespace NatLaRestTest.Services.Helpers.HttpMessageContentBeautifier;

internal class XmlContentStringBeautifier: IContentTypeSpecificContentStringBeautifier
{
    public string Beautify(string content)
    {
        var xDoc = XDocument.Parse(content);
        return xDoc.ToString();
    }
}