using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Engine.Zones;

public static class ServiceCollectionExtensions
{
    public static void AddZones(this IServiceCollection source)
    {
        source.AddSingleton<IZoneManager, ZoneManager>();
        source.AddSingleton<IMvvmObjectFactory, MvvmObjectFactory>();
    }
}
