using MyFirstApi.Models;

namespace MyFirstApi.Strategies;

public class FedExExpressStrategy : IShippingCostStrategy
{
    public decimal Calculate(Order order)
    {
        return 25.00m;
    }
}