
using MyFirstApi.Strategies;

namespace MyFirstApi.Factories;

public class ShippingCostStrategyFactory : IShippingCostStrategyFactory
{
    private readonly Dictionary<string, IShippingCostStrategy> _strategies;

    public ShippingCostStrategyFactory(IEnumerable<IShippingCostStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(
            strategy => strategy.GetType().Name.Replace("ShippingStrategy", "").ToLower(),
            strategy => strategy
        );
    }

    public IShippingCostStrategy Create(string provider)
    {
        if (_strategies.TryGetValue(provider.ToLower(), out var strategy))
        {
            return strategy;
        }
        throw new ArgumentException("Invalid shipping provider", nameof(provider));
    }
}