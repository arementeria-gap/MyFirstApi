using MyFirstApi.Models;

namespace MyFirstApi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}