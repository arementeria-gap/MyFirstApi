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

        List<Product> products = [];

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}