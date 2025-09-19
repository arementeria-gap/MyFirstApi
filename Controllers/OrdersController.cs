using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;
using MyFirstApi.Factories;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IShippingCostStrategyFactory strategyFactory, ShippingProviderAbstractFactory abstractFactory) : ControllerBase
{
    private readonly ShippingProviderAbstractFactory _abstractFactory = abstractFactory;
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

    [HttpPost("process-shipping")]
    public ActionResult<string> ProcessShipping([FromBody] Order order, [FromQuery] string serviceTier)
    {
        try
        {
            IShippingProviderFactory providerFactory = _abstractFactory.CreateFactory(serviceTier);

            var costStrategy = providerFactory.CreateShippingStrategy();
            var labelGenerator = providerFactory.CreateLabelGenerator();

            // 3. Use the services to process the order.
            var shippingService = new ShippingCostService(costStrategy);
            decimal cost = shippingService.CalculateShippingCost(order);
            string label = labelGenerator.GenerateLabel(order);

            return Ok($"Shipping Cost: {cost:C}, Label: {label}");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}