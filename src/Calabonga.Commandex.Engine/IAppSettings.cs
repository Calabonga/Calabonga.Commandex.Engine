namespace Calabonga.Commandex.Engine;

/// <summary>
/// Application settings loaded from environment file from the Shell instance
/// </summary>
public interface IAppSettings
{
    /// <summary>
    /// Where Commandex will search the commands
    /// </summary>
    string CommandsPath { get; }

    /// <summary>
    /// If True then search bar on the top of the commands list will be visible by default.
    /// </summary>
    bool ShowSearchPanelOnStartup { get; }

    /// <summary>
    /// Artifacts folder name
    /// </summary>
    string ArtifactsFolderName { get; }
}