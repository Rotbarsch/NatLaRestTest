namespace NatLaRestTest.Services.Interfaces;

public interface IContentStringBeautifier
{
    public string Beautify(string contentString, string? contentType);
    public string EnforceLength(string contentString);
}