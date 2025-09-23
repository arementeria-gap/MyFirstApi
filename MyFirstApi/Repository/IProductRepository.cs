using MyFirstApi.Models;

namespace MyFirstApi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<IEnumerable<Product>> GetProductsByColor(string color);
}