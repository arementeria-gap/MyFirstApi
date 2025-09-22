using MyFirstApi.Models;
namespace MyFirstApi.Strategies;

public class FedExGroundStrategy : IShippingCostStrategy
{
    public decimal Calculate(Order order)
    {
        return 7.50m;
    }
}