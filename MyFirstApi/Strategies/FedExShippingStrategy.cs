using MyFirstApi.Models;

namespace MyFirstApi.Strategies;

public class FedExShippingStrategy : IShippingCostStrategy
{
    public decimal Calculate(Order order)
    {
        return 5.00m;
    }
}