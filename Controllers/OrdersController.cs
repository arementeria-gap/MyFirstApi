using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Strategies;
using MyFirstApi.Services;
using MyFirstApi.Factories;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IShippingCostStrategyFactory strategyFactory) : ControllerBase
{
    private readonly IShippingCostStrategyFactory _strategyFactory = strategyFactory;
    [HttpPost("calculate-shipping")]
    public ActionResult<decimal> CalculateShipping([FromBody] Order order, [FromQuery] string provider)
    {
        try
        {
            var strategy = _strategyFactory.Create(provider);
            var shippingService = new ShippingCostService(strategy);
            return Ok(shippingService.CalculateShippingCost(order));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}