namespace Calabonga.Commandex.Engine.Settings;

/// <summary>
/// Application settings imported from .env-file with parameters.
/// </summary>
public class AppSettings : IAppSettings
{
    /// <summary>
    /// Where Commandex will search the commands
    /// </summary>
    public required string CommandsPath { get; init; }

    /// <summary>
    /// If True then search bar on the top of the commands list will be visible by default.
    /// </summary>
    public bool ShowSearchPanelOnStartup { get; init; }

    /// <summary>
    /// Artifacts folder name
    /// </summary>
    public required string ArtifactsFolderName { get; init; }

    /// <summary>
    /// Nuget Feed URL
    /// </summary>
    public required string NugetFeedUrl { get; init; }
}
