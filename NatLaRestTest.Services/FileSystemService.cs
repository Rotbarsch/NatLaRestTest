using NatLaRestTest.Core.Contracts.Settings;
using NatLaRestTest.Services.Interfaces;
using NUnit.Framework;

namespace NatLaRestTest.Services;

public class FileSystemService(
    INatLaRestTestSettingsService settingsService,
    IVariableService variableService,
    ITestOutputLoggingService loggingService)
    : IFileSystemService
{
    private readonly ITestOutputLoggingService _loggingService = loggingService;
    private readonly IEnumerable<FileRedirect> _fileRedirects = settingsService.GetFileRedirects();

    public string? GetContentFromFile(string filePath)
    {
        var existingFileRedirect = _fileRedirects.FirstOrDefault(x => string.Equals(x.OriginalFileName, filePath, StringComparison.CurrentCultureIgnoreCase));
        var actualFilePath = variableService.ResolvePlaceHolderString(existingFileRedirect?.Redirect ?? filePath);

        Assert.NotNull(actualFilePath);
        Assert.IsNotEmpty(actualFilePath);

        var resolvedFilePath = variableService.ResolvePlaceHolderString(actualFilePath!);
        if (File.Exists(resolvedFilePath))
        {
            return File.ReadAllText(resolvedFilePath);
        }
        
        Assert.Fail($"File '{filePath}' (resolved to '{actualFilePath}') not found.");
        return null;
    }
}