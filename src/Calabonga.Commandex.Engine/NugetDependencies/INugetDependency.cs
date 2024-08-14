namespace Calabonga.Commandex.Engine.NugetDependencies;

/// <summary>
/// // Calabonga: Summary required (INugetDependency 2024-08-14 01:23)
/// </summary>
public interface INugetDependency
{
    Type Type { get; }

    List<NugetDependency> Dependencies { get; }
}