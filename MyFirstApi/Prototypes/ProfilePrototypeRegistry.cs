using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using MyFirstApi.Models;

namespace MyFirstApi.Prototypes;

public class ProfilePrototypeRegistry
{
    private readonly Dictionary<string, UserProfile> _prototypes = new();

    public ProfilePrototypeRegistry()
    {
        var defaultUser = new UserProfile();
        var adminUser = new UserProfile
        {
            Theme = "dark",
            Language = "en-GB"
        };

        _prototypes.Add("default", defaultUser);
        _prototypes.Add("admin", adminUser);
    }

    public UserProfile? GetPrototype(string key)
    {
        if (_prototypes.TryGetValue(key.ToLower(), out var prototype))
        {
            return prototype.Clone();
        }
        return null;
    }
}