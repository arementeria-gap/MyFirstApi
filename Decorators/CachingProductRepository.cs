using MyFirstApi.Repository;
using MyFirstApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MyFirstApi.Decorators;

public class CachingProductRepository : IProductRepository
{
    private readonly IProductRepository _decoratedRepository;
    private readonly IMemoryCache _cache;
    private const string ProductsCacheKey = "AllProducts";
    
    public CachingProductRepository(IProductRepository decoratedRepository, IMemoryCache cache)
    {
        _decoratedRepository = decoratedRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        if (_cache.TryGetValue(ProductsCacheKey, out IEnumerable<Product>? cachedProducts))
        {
            Console.WriteLine("--- Returning products from CACHE ---");
            return cachedProducts!;
        }

        Console.WriteLine("--- Fetching products from DATABASE ---");
        var products = await _decoratedRepository.GetAllAsync();

        // 3. Save the result in the cache for next time.
        _cache.Set(ProductsCacheKey, products, TimeSpan.FromMinutes(1));

        return products;
    }
}