using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Extensions for IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers zones
    /// </summary>
    /// <param name="source"></param>
    public static void AddZones(this IServiceCollection source)
    {
        source.AddSingleton<IZoneManager, ZoneManager>();
        source.AddSingleton<IMvvmObjectFactory, MvvmObjectFactory>();
    }
}
