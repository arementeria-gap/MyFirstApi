using MyFirstApi.Models;

namespace MyFirstApi.Builders;

public class ShippingManifestBuilder : IManifestBuilder
{
    private ShippingManifest _manifest = new();

    public void Reset()
    {
        _manifest = new();
    }

    public IManifestBuilder BuildHeader(Order order)
    {
        _manifest.Header = $"--- MANIFEST FOR ORDER #{order.Id} ---";
        return this;
    }
    public IManifestBuilder BuildProductList(IEnumerable<Product> products)
    {
         _manifest.ProductList = "Products:\n" + 
                                string.Join("\n", products.Select(p => $"- {p.Name} ({p.ListPrice:C})"));
        return this;
    }
     public IManifestBuilder BuildCustomsInfo(Order order)
    {
        // Example: Only add customs info for high-value orders
        if (order.Total > 1000)
        {
            _manifest.CustomsInformation = "[CUSTOMS FORM ATTACHED]";
        }
        return this;
    }
    public IManifestBuilder BuildInsuranceInfo(Order order)
    {
        _manifest.InsuranceDetails = $"[INSURANCE ADDED FOR ORDER VALUE: {order.Total:C}]";
        return this;
    }

    public ShippingManifest GetManifest()
    {
        ShippingManifest result = _manifest;
        Reset();
        return result;
    }
}