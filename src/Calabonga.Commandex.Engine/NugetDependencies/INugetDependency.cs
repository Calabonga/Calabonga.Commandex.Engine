namespace Calabonga.Commandex.Engine.NugetDependencies;

/// <summary>
/// Nuget dependency definition from command to shell
/// </summary>
public interface INugetDependency
{
    /// <summary>
    /// Type of the command which needs dependencies
    /// </summary>
    Type Type { get; }

    /// <summary>
    /// A list of the dependencies
    /// </summary>
    List<NugetDependency> Dependencies { get; }
}
