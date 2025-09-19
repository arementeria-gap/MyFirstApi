using System.Text;

namespace MyFirstApi.Models;

public class ShippingManifest
{
    public string? Header { get; set; }
    public string? ProductList { get; set; }
    public string? CustomsInformation { get; set; }
    public string? InsuranceDetails { get; set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        if (Header != null) builder.AppendLine(Header);
        if (ProductList != null) builder.AppendLine(ProductList);
        if (CustomsInformation != null) builder.AppendLine(CustomsInformation);
        if (InsuranceDetails != null) builder.AppendLine(InsuranceDetails);
        return builder.ToString();
    }
}