using MyFirstApi.Services;
using MyFirstApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApiContext>(options => 
    options.UseInMemoryDatabase("ProductDb"));
builder.Services.AddScoped<ProductService>();
// builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// --- Add this block of code ---
// Get the ProductService so we can subscribe to its event
#region Event Subscription
/**
var productService = app.Services.GetRequiredService<ProductService>();

// Use the += operator to subscribe a method to the event
productService.ProductsRetrieved += async (source, args) =>
{
    await Task.Delay(1);
    Console.WriteLine("EVENT SUBSCRIBER: The product list was requested!");
};

productService.ProductsRetrieved += async (source, args) =>
{
    await Task.Delay(10000);
    Console.WriteLine("Could it be that this is also triggered?");
};
**/
#endregion
// --- End of block ---

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
