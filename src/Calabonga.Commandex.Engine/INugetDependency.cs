namespace Calabonga.Commandex.Engine;

public interface INugetDependency
{
    Type Type { get; }

    List<NugetDependency> Dependencies { get; }
}