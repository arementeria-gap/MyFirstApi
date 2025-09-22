using MyFirstApi.Models;
using MyFirstApi.Strategies;

namespace MyFirstApi.Services;

public class ShippingCostService(IShippingCostStrategy strategy)
{
    private IShippingCostStrategy _strategy = strategy;

    public void SetStrategy(IShippingCostStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateShippingCost(Order order)
    {
        return _strategy.Calculate(order);
    }
}