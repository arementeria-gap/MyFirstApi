using MyFirstApi.Models;

namespace MyFirstApi.Data;

public static class DbInitializer
{
    public static void Initialize(ApiContext context)
    {
        // Look for any products.
        if (context.Products.Any())
        {
            return;   // If the DB has data, do nothing.
        }

        var products = new Product[]
        {
            new() { Id = 1, Name = "Laptop", Price = 1200.00m },
            new() { Id = 2, Name = "Mouse", Price = 45.50m },
            new() { Id = 3, Name = "Keyboard", Price = 99.99m }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}