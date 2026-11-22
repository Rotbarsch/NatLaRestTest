using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Channels;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<EventBroker>();

        // Add services to the container.
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.Use(async (context, next) =>
        {
            context.Response.Headers.Append("x-application", "NatLaDemoApi");
            context.Response.Headers.Expires = DateTime.Now.AddDays(1).ToString("O");
            await next.Invoke();
        });

        // For response codes
        app.MapGet("/ok", () => Results.Ok("works"));
        app.MapPost("/create", () => Results.Created());
        app.MapGet("/missing", () => Results.NotFound());

        app.MapPost("/upload", async (HttpRequest request) =>
        {
            using var reader = new StreamReader(request.Body);
            var content = await reader.ReadToEndAsync();
            var contentType = request.ContentType ?? "unknown";

            return Results.Ok(new { contentType, size = content.Length, content });
        });

        app.MapPut("/upload", async (HttpRequest request) =>
        {
            using var reader = new StreamReader(request.Body);
            var content = await reader.ReadToEndAsync();
            var contentType = request.ContentType ?? "unknown";

            return Results.Ok(new { contentType, size = content.Length, content });
        });

        // Forms
        app.MapPost("/upload/form", async (HttpRequest request) =>
        {
            if (!request.HasFormContentType)
                return Results.BadRequest("Expected multipart/form-data content.");

            var form = await request.ReadFormAsync();
            var file = form.Files.FirstOrDefault();

            if (file is null || file.Length == 0)
                return Results.BadRequest("No file uploaded.");

            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Results.Ok(new { fileName = file.FileName, size = file.Length, content });
        }).DisableAntiforgery();

        app.MapPost("/upload/form/named", async (HttpRequest request) =>
        {
            if (!request.HasFormContentType)
                return Results.BadRequest("Expected multipart/form-data content.");

            var form = await request.ReadFormAsync();
            var file = form.Files.FirstOrDefault();

            if (file is null || file.Length == 0)
                return Results.BadRequest("No file uploaded.");

            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            return Results.Ok(new { fieldName = file.Name, fileName = file.FileName, size = file.Length, content });
        }).DisableAntiforgery();

        app.MapPost("/form", async (HttpRequest request) =>
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            var fields = QueryHelpers.ParseQuery(body)
                .ToDictionary(kv => kv.Key, kv => kv.Value.FirstOrDefault() ?? "");
            return Results.Ok(new { contentType = request.ContentType, fields });
        }).DisableAntiforgery();

        app.MapPut("/form", async (HttpRequest request) =>
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            var fields = QueryHelpers.ParseQuery(body)
                .ToDictionary(kv => kv.Key, kv => kv.Value.FirstOrDefault() ?? "");
            return Results.Ok(new { contentType = request.ContentType, fields });
        }).DisableAntiforgery();

        // Headers
        app.MapGet("/require-natla-header", async (HttpRequest request) =>
        {
            if (request.Headers.TryGetValue("x-application", out Microsoft.Extensions.Primitives.StringValues value) && value == "NatLaRestTest")
            {
                return Results.Ok();
            }
            return Results.BadRequest();
        });

        // SSE
        app.MapGet("/publish", async (EventBroker eventBroker) =>
        {
            await eventBroker.PublishAsync(new ServerEvent { Value = DateTime.Now.ToString("O") });
            return Results.Ok();
        });

        app.MapGet("/subscribe", async (HttpContext context, EventBroker eventBroker, CancellationToken cancellationToken) =>
        {
            var guid = Guid.NewGuid();
            var channel = eventBroker.Subscribe(guid);

            context.Response.Headers.ContentType = "text/event-stream";
            context.Response.Headers.CacheControl = "no-cache";
            context.Response.Headers.Connection = "keep-alive";
            context.Response.Headers["X-Accel-Buffering"] = "no";

            try
            {
                await foreach(var serverEvent in channel.Reader.ReadAllAsync(context.RequestAborted))
                {
                    var json = JsonSerializer.Serialize(serverEvent);
                    await context.Response.WriteAsync($"data: {json}\n\n", context.RequestAborted);
                    await context.Response.WriteAsync($"eventType: message\n\n", context.RequestAborted);
                    await context.Response.Body.FlushAsync(context.RequestAborted);
                }
            }
            catch (OperationCanceledException)
            {
                // Client disconnected
            }
            finally
            {
                eventBroker.Unsubscribe(guid);
            }
        });

        await app.RunAsync();
    }
}

internal class EventBroker
{
    private readonly ConcurrentDictionary<Guid, Channel<ServerEvent>> _subscribers = new();

    public Channel<ServerEvent> Subscribe(Guid subscriberId)
    {
        var channel = Channel.CreateUnbounded<ServerEvent>();
        _subscribers.TryAdd(subscriberId, channel);
        return channel;
    }

    public void Unsubscribe(Guid subscriberId)
    {
        if(_subscribers.TryRemove(subscriberId,out var channel))
        {
            channel.Writer.TryComplete();
        }
    }

    public async Task PublishAsync(ServerEvent serverEvent)
    {
        foreach(var channel in _subscribers.Values)
        {
            await channel.Writer.WriteAsync(serverEvent);
        }
    }
}

internal record ServerEvent
{
    public required string Value { get; init; }
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.UtcNow;
}

namespace NatLaRestTest.DemoWebApi
{
    public partial class Program { }
}
