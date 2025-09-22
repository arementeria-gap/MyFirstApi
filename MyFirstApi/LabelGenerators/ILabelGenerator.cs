using MyFirstApi.Models;

namespace MyFirstApi.LabelGenerators;

public interface ILabelGenerator
{
    string GenerateLabel(Order order);
}