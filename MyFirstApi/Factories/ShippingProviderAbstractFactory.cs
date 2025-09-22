namespace MyFirstApi.Factories;

public class ShippingProviderAbstractFactory
{
    private readonly IReadOnlyDictionary<string, IShippingProviderFactory> _factories;

    public ShippingProviderAbstractFactory(IEnumerable<IShippingProviderFactory> factories)
    {
        _factories = factories.ToDictionary(
            factory => factory.GetType().Name.Replace("Factory", "").ToLower(),
            factory => factory
        );
    }

    public IShippingProviderFactory CreateFactory(string serviceTier)
    {
        if (_factories.TryGetValue(serviceTier.ToLower(), out var factory))
        {
            return factory;
        }

        throw new ArgumentException("Invalid shipping provider.", nameof(serviceTier));
    }
}