
using MyFirstApi.Data;
using MyFirstApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Models;

public class ProductRepository(ApiContext context) : IProductRepository
{
    private readonly ApiContext _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}