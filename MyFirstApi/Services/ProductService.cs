using MyFirstApi.Models;
using MyFirstApi.Repository;
namespace MyFirstApi.Services;

public class ProductService(IProductRepository repository)
{
    private readonly IProductRepository _repository = repository;

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByColor(string color)
    {
        return await _repository.GetProductsByColor(color);
    }
}