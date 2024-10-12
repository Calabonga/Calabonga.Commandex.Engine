using Calabonga.Commandex.Engine.Settings;
using DotNetEnv;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Environment Loaded for Command
/// </summary>
public abstract class SettingsBase
{
    protected SettingsBase(IAppSettings shellSettings, ISettingsReaderConfiguration settingsReader)
    {
        ShellSettings = shellSettings;

        var settingsPath = shellSettings.SettingsPath.EndsWith('/') ? shellSettings.SettingsPath : $"{shellSettings.SettingsPath}/";
        var currentAssemblyName = settingsReader.GetEnvironmentFileName(GetType());
        var defaultConfigurationFileExtension = settingsReader.GetExtensionFileName();
        var commandSettingsFile = $"{settingsPath}{currentAssemblyName}{defaultConfigurationFileExtension}";

        Env.Load(commandSettingsFile);
    }

    /// <summary>
    /// Shell Application Settings
    /// </summary>
    public IAppSettings ShellSettings { get; }
}
