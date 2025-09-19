using MyFirstApi.LabelGenerators;
using MyFirstApi.Models;

namespace MyFirstApi.Strategies;

public class FedExExpressLabelGenerator : ILabelGenerator
{
    public string GenerateLabel(Order order)
    {
        return $"[FedEx EXPRESS Label for Order #{order.Id}]";
    }
}