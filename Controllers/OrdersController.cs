using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Strategies;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost("calculate-shipping")]
    public ActionResult<decimal> CalculateShipping([FromBody] Order order, [FromQuery] string provider)
    {
        IShippingCostStrategy strategy;
        switch (provider.ToLower())
        {
            case "fedex":
                strategy = new FedExShippingStrategy();
                break;
            case "ups":
                strategy = new UPSShippingStrategy();
                break;
            default:
                return BadRequest("Invalid shipping provider");
        }
        var shippingService = new ShippingCostService(strategy);
        return Ok(shippingService.CalculateShippingCost(order));
    }
}