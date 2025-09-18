using MyFirstApi.Strategies;

namespace MyFirstApi.Factories;

public interface IShippingCostStrategyFactory
{
    IShippingCostStrategy Create(string provider);
}