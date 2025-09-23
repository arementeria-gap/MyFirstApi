using Moq;
using MyFirstApi.Models;
using MyFirstApi.Repository;
using MyFirstApi.Services;
using Shouldly;

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
            new Product { ProductId = 1, Name = "Test Product", ListPrice = 10.99m }
        };

        mockRepository.Setup(repo => repo.GetAllAsync())
                     .ReturnsAsync(expectedProducts);

        var productService = new ProductService(mockRepository.Object);

        // Act
        var result = await productService.GetAllAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test Product", result.First().Name);

        result.ShouldHaveSingleItem();
        result.First().Name.ShouldBe("Test Product");
    }
}
