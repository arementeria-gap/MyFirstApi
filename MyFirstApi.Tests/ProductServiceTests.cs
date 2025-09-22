using Moq;
using MyFirstApi.Models;
using MyFirstApi.Repository;
using MyFirstApi.Services;

namespace MyFirstApi.Tests;

public class ProductServiceTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnProducts()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        var expectedProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Test Product", Price = 10.99m }
        };
        
        mockRepository.Setup(repo => repo.GetAllAsync())
                     .ReturnsAsync(expectedProducts);
        
        var productService = new ProductService(mockRepository.Object);

        // Act
        var result = await productService.GetAllAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test Product", result.First().Name);
    }
}
