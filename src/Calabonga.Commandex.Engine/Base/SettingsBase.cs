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

        var path = shellSettings.CommandsPath.EndsWith('/') ? shellSettings.CommandsPath : $"{shellSettings.CommandsPath}/";
        var currentAssemblyName = settingsReader.GetEnvironmentFileName(GetType());
        var defaultConfigurationFileExtension = settingsReader.GetExtensionFileName();
        var environmentFileName = $"{path}{currentAssemblyName}{defaultConfigurationFileExtension}";

        Env.Load(environmentFileName);
    }

    /// <summary>
    /// Shell Application Settings
    /// </summary>
    public IAppSettings ShellSettings { get; }
}
