using System.Diagnostics;
using NatLaRestTest.Services.Interfaces;
using Reqnroll;

namespace NatLaRestTest.Bindings.Utility;

/// <summary>
/// Debug bindings.
/// </summary>
/// <param name="loggingService"></param>
/// <param name="debugUtilityService"></param>
[Binding]
public class DebugBindings(ITestOutputLoggingService loggingService, IDebugUtilityService debugUtilityService)
{
    private IDebugUtilityService Debug { get; init; } = debugUtilityService;


    /// <summary>
    /// Special binding for entering NatLaRestTest debug mode.
    /// </summary>
    [Then("enter debug mode")]
    public void EnterDebugMode()
    {
        if (Debugger.IsAttached)
        {
            Debugger.Break();
        }
        else
        {
            loggingService.WriteLine("Unable to enter debug mode since no Debugger is attached.");
        }
    }
}