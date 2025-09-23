
using MyFirstApi.Data;
using MyFirstApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Models;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByColor(string color)
    {
        return await _context.Products.Where(p => p.Color == color).ToListAsync();
    }
}