using MyFirstApi.Models;

namespace MyFirstApi.Builders;

public interface IManifestBuilder
{
    IManifestBuilder BuildHeader(Order order);
    IManifestBuilder BuildProductList(IEnumerable<Product> products);
    IManifestBuilder BuildCustomsInfo(Order order);
    IManifestBuilder BuildInsuranceInfo(Order order);

    ShippingManifest GetManifest();
}