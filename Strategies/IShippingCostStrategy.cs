using MyFirstApi.Models;

namespace MyFirstApi.Strategies;

public interface IShippingCostStrategy
{
    decimal Calculate(Order order);
}