# NatLaRestTest.Demo

A collection of demo features demonstrating the capabilities of the NatLaRestTest library.

## How to run
These tests expect to find a running instance of the NatLaRestTest.DemoWebApi service listening on `https://localhost:7031`.

Assuming you're in the project root:
1. Start the DemoWebApi with the following command:
```
dotnet run --project .\NatLaRestTest.DemoWebApi\NatLaRestTest.DemoWebApi.csproj --launch-profile https
```
2. With the service running, open a new terminal and run the tests (or use your IDE of choice):
```
dotnet test --project .\NatLaRestTest.Demo\NatLaRestTest.Demo.csproj
```

3. After the tests complete, stop the DemoWebApi service with Ctrl+C in the terminal where it's running.

## Changing the port
If you need to change the port that the DemoWebApi service listens on, update both the launch profile in `NatLaRestTest.DemoWebApi/Properties/launchSettings.json` and the base URL in `NatLaRestTest.Demo/reqnroll.json`, specifically the `demoApiBaseUrl` variable under `testVariables`.