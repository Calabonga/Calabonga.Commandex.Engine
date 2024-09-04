using Calabonga.Commandex.Engine.Base;
using DotNetEnv;

namespace Calabonga.Commandex.Engine.Settings;

/// <summary>
/// Environment Loaded for Command
/// </summary>
public abstract class SettingsBase
{
    public IAppSettings ShellSettings { get; }

    protected SettingsBase(IAppSettings shellSettings, ISettingsReaderConfiguration settingsReader)
    {
        ShellSettings = shellSettings;

        var path = shellSettings.CommandsPath.EndsWith('/') ? shellSettings.CommandsPath : $"{shellSettings.CommandsPath}/";
        var currentAssemblyName = settingsReader.GetEnvironmentFileName();
        var defaultConfigurationFileExtension = settingsReader.GetExtensionFileName();
        var environmentFileName = $"{path}{currentAssemblyName}{defaultConfigurationFileExtension}";

        Env.Load(environmentFileName);
    }
}