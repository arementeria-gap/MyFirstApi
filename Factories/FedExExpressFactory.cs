using MyFirstApi.LabelGenerators;
using MyFirstApi.Strategies;

namespace MyFirstApi.Factories;

public class FedExExpressFactory : IShippingProviderFactory
{
    public IShippingCostStrategy CreateShippingStrategy()
    {
        return new FedExExpressStrategy();
    }

    public ILabelGenerator CreateLabelGenerator()
    {
        return new FedExExpressLabelGenerator();
    }
}