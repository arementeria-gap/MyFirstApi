using MyFirstApi.Services;
using MyFirstApi.Data;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Repository;
using MyFirstApi.Models;
using MyFirstApi.Factories;
using MyFirstApi.Strategies;
using MyFirstApi.Builders;
using MyFirstApi.Prototypes;
using MyFirstApi.Decorators;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApiContext>(options => 
    options.UseInMemoryDatabase("ProductDb"));

// builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<IProductRepository, CachingProductRepository>(sp =>
    new CachingProductRepository(
        sp.GetRequiredService<ProductRepository>(),
        sp.GetRequiredService<IMemoryCache>()
    ));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<LifecyclesService>();
builder.Services.AddTransient<LifecyclesSupportService>();

builder.Services.AddTransient<IShippingCostStrategy, FedExShippingStrategy>();
builder.Services.AddTransient<IShippingCostStrategy, UPSShippingStrategy>();
builder.Services.AddSingleton<IShippingCostStrategyFactory, ShippingCostStrategyFactory>();

builder.Services.AddSingleton<ShippingProviderAbstractFactory>();

builder.Services.AddTransient<IShippingProviderFactory, FedExGroundFactory>();
builder.Services.AddTransient<IShippingProviderFactory, FedExExpressFactory>();

builder.Services.AddTransient<IManifestBuilder, ShippingManifestBuilder>();

builder.Services.AddSingleton<ProfilePrototypeRegistry>();

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
