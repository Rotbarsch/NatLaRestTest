namespace NatLaRestTest.Services.Helpers.HttpMessageContentBeautifier;

internal interface IContentTypeSpecificContentStringBeautifier
{
    string Beautify(string content);
}