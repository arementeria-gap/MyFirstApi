using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;
using MyFirstApi.Factories;
using MyFirstApi.Builders;
using MyFirstApi.Repository;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ShippingProviderAbstractFactory _abstractFactory;
    private readonly IShippingCostStrategyFactory _strategyFactory;
    private readonly IManifestBuilder _manifestBuilder;
    private readonly IProductRepository _productRepository;

    // Inject the new services
    public OrdersController(
        IShippingCostStrategyFactory strategyFactory,
        ShippingProviderAbstractFactory abstractFactory,
        IManifestBuilder manifestBuilder,
        IProductRepository productRepository)
    {
        _strategyFactory = strategyFactory;
        _abstractFactory = abstractFactory;
        _manifestBuilder = manifestBuilder;
        _productRepository = productRepository;
    }

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
    
    // --- Add this new endpoint ---
    [HttpPost("generate-manifest")]
    public async Task<ActionResult<string>> GenerateManifest([FromBody] Order order, [FromQuery] bool addInsurance = false)
    {
        // In a real app, you'd get the products associated with the order
        var allProducts = await _productRepository.GetAllAsync();

        // Use the builder to construct the manifest step-by-step
        _manifestBuilder
            .BuildHeader(order)
            .BuildProductList(allProducts)
            .BuildCustomsInfo(order);

        // Conditionally add an optional part
        if (addInsurance)
        {
            _manifestBuilder.BuildInsuranceInfo(order);
        }

        ShippingManifest manifest = _manifestBuilder.GetManifest();

        // We return the formatted string from the manifest's ToString() method
        return Ok(manifest.ToString());
    }
}