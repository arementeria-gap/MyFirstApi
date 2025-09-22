using MyFirstApi.Models;

namespace MyFirstApi.LabelGenerators;

public class FedExGroundLabelGenerator : ILabelGenerator
{
    public string GenerateLabel(Order order)
    {
        return $"[FedEx Ground Label for Order #{order.Id}]";
    }
}