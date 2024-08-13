namespace Calabonga.Commandex.Engine.NugetDependencies
{
    public interface INugetDependency
    {
        Type Type { get; }

        List<NugetDependency> Dependencies { get; }
    }
}