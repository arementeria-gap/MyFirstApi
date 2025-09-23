using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;           // Add this

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(ProductService service) : ControllerBase
{
    private readonly ProductService _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("color/{color}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByColor(string color)
    {
        var products = await _service.GetProductsByColor(color);
        if (products == null || !products.Any())
        {
            return NotFound($"no product with the color '{color}'");
        }
        return Ok(products);
    }
} 