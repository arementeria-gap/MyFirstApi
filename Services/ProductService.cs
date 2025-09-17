using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;
namespace MyFirstApi.Services;

public class ProductService
{
    private readonly ApiContext _context;

    public ProductService(ApiContext context)
    {
        _context = context;
    }

    // --- Add this code ---
    #region Event Handling
    // 1. Define a delegate that specifies the event's signature
    public delegate Task ProductsRetrievedEventHandler(object source, EventArgs args);

    // 2. Define the event using the delegate
    public event ProductsRetrievedEventHandler? ProductsRetrieved;

    // 3. Create a protected method to raise the event
    protected virtual void OnProductsRetrieved()
    {
        // Check if there are any subscribers before raising the event
        ProductsRetrieved?.Invoke(this, EventArgs.Empty);
    }
    #endregion
    // --- End of new code ---

    private readonly List<string> _products = new()
    {
        "Laptop", "Mouse", "Keyboard"
    };

    public async Task<List<Product>> GetAll()
    {
        Console.WriteLine("ProductService: Getting all products...");

        // 4. Raise the event whenever products are requested
        OnProductsRetrieved();

        return await _context.Products.ToListAsync();
    }
}