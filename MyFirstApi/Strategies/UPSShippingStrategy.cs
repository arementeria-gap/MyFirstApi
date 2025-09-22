using MyFirstApi.Models;

namespace MyFirstApi.Strategies;

public class UPSShippingStrategy : IShippingCostStrategy
{
    public decimal Calculate(Order order)
    {
        return order.Total * 0.04m;
    }
}