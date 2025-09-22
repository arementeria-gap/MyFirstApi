using MyFirstApi.LabelGenerators;
using MyFirstApi.Strategies;

namespace MyFirstApi.Factories;

public class FedExGroundFactory : IShippingProviderFactory
{
    public IShippingCostStrategy CreateShippingStrategy()
    {
        return new FedExGroundStrategy();
    }

    public ILabelGenerator CreateLabelGenerator()
    {
        return new FedExGroundLabelGenerator();
    }
}