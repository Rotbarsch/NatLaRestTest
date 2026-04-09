var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

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

await app.RunAsync();

namespace NatLaRestTest.DemoWebApi
{
    public partial class Program { }
}
