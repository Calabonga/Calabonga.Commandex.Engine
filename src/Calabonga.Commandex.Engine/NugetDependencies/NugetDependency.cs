namespace Calabonga.Commandex.Engine.NugetDependencies;

/// <summary>
/// Dependency description for Commandex Shell
/// </summary>
public sealed class NugetDependency
{
    /// <summary>
    /// Nuget-package full name, like "Calabonga.TokenGeneratorCore"
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Nuget-package version, like "1.0.0"
    /// </summary>
    public required string Version { get; set; }
}