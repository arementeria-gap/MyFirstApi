using MyFirstApi.LabelGenerators;
using MyFirstApi.Strategies;

namespace MyFirstApi.Factories;

public interface IShippingProviderFactory
{
    IShippingCostStrategy CreateShippingStrategy();
    ILabelGenerator CreateLabelGenerator();
}