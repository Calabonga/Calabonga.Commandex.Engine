﻿namespace Calabonga.Commandex.Engine.Settings;

/// <summary>
/// Application settings loaded from environment file from the Shell instance
/// </summary>
public interface IAppSettings
{
    /// <summary>
    /// Where Commandex will search a commands
    /// </summary>
    string CommandsPath { get; }

    /// <summary>
    /// Where Commandex will search a settings files for commands
    /// </summary>
    string SettingsPath { get; }

    /// <summary>
    /// If True then search bar on the top of the commands list will be visible by default.
    /// </summary>
    bool ShowSearchPanelOnStartup { get; }

    /// <summary>
    /// Artifacts folder name
    /// </summary>
    string ArtifactsFolderName { get; }

    /// <summary>
    /// Nuget artifacts feed URL. Default is https://api.nuget.org/v3/index.json
    /// </summary>
    string NugetFeedUrl { get; }
}
