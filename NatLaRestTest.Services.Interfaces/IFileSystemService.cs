namespace NatLaRestTest.Services.Interfaces;

public interface IFileSystemService
{
    string? GetContentFromFile(string filePath);
}