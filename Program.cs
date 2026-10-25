using wt_lab6_6minimalapi_alasevic.Data;
using wt_lab6_6minimalapi_alasevic.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () =>
{
    return new
    {
        Application = "Web Technologies",
        Technology = "ASP.NET Core Minimal API",
        Version = "1.0"
    };
});

app.MapGet("/api/products", (string? search) =>
{
   
    var products = ProductStore.Products.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        products = products.Where(x => 
            x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(products);
});

app.MapGet("/api/products/{id}", (int id) =>
{
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);

    if (product == null)
    {
        return Results.NotFound();
    }
  
    return Results.Ok(product);
});

app.MapPost("/api/products", (Product product) =>
{
    
    product.Id = ProductStore.Products.Count == 0
        ? 1
        : ProductStore.Products.Max(x => x.Id) + 1;

    ProductStore.Products.Add(product);

    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapPut("/api/products/{id}", (int id, Product updatedProduct) =>
{
    
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);
    
    if (product == null)
    {
        return Results.NotFound();
    }

    product.Name = updatedProduct.Name;
    product.Category = updatedProduct.Category;
    product.Price = updatedProduct.Price;
    product.IsAvailable = updatedProduct.IsAvailable;

    return Results.Ok(product);
});

app.MapDelete("/api/products/{id}", (int id) =>
{
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);
    
    if (product == null)
    {
        return Results.NotFound();
    }

    ProductStore.Products.Remove(product);

    return Results.NoContent();
});
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");

