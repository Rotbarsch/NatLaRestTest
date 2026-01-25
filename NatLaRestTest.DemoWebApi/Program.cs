using System.Net.Mime;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/ok", () => Results.Ok("works"));
app.MapPost("/create", () => Results.Created());
app.MapGet("/missing", () => Results.NotFound());

await app.RunAsync();