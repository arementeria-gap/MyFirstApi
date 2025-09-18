using MyFirstApi.Services;
using MyFirstApi.Data;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Repository;
using MyFirstApi.Models;
using MyFirstApi.Factories;
using MyFirstApi.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApiContext>(options => 
    options.UseInMemoryDatabase("ProductDb"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<LifecyclesService>();
builder.Services.AddTransient<LifecyclesSupportService>();

builder.Services.AddTransient<IShippingCostStrategy, FedExShippingStrategy>();
builder.Services.AddTransient<IShippingCostStrategy, UPSShippingStrategy>();
builder.Services.AddSingleton<IShippingCostStrategyFactory, ShippingCostStrategyFactory>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApiContext>();

    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
