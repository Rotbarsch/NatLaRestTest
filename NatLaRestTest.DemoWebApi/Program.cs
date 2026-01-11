using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

int entityIdCounter = 0;
List<Dictionary<string, object>> entityStore = new();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/cat", () =>
{
    var resourceName = "NatLaRestTest.DemoWebApi.cat.jpg";
    var img = typeof(Program).Assembly.GetManifestResourceStream(resourceName);
    return Results.File(img, MediaTypeNames.Image.Jpeg);
});

app.MapGet("/products", () =>
{
    return new
    {
        products = new[]
        {
            new { id=1, name = "Banana", self_link="/shop/v2/products/1", price = 0.99 },
            new { id=2, name = "Apple", self_link="/shop/v2/products/2", price = 1.99 }
        }
    };
});

app.MapGet("/products/1", () => new { id = 1, name = "Banana", self_link = "/shop/v2/products/1", price = 0.99 });

app.MapPost("/objects", ([FromBody] Dictionary<string, object> entity) =>
{
    entity.Add("id", entityIdCounter++);

    entityStore.Add(entity);

    return entity;
});

app.MapDelete("/objects/{id}", (int id) =>
{
    var toDelete = entityStore.SingleOrDefault(x => (int)x["id"] == id);
    if (toDelete is null)
    {
        return Results.NotFound();
    }

    entityStore.Remove(toDelete);
    return Results.Ok(new
    {
        message = $"Entity id = {id} has been deleted."
    });
});

app.MapGet("/objects/{id}", (int id) =>
{
    var toReturn = entityStore.SingleOrDefault(x => (int)x["id"] == id);
    if (toReturn is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(toReturn);
});

app.MapPost("/upload", async (HttpRequest request) =>
{
    using var sr = new StreamReader(request.Body);
    var body = await sr.ReadToEndAsync();
    return body.Length;
}).DisableAntiforgery();

app.Run();
