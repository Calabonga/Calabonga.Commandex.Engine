using DotNetEnv;

namespace Calabonga.Commandex.Engine.Settings
{
    /// <summary>
    /// Environment Loaded for Command
    /// </summary>
    public abstract class SettingsBase
    {
        protected SettingsBase(string commandsPath)
        {
            var path = commandsPath.EndsWith('/') ? commandsPath : $"{commandsPath}/";
            var currentAssemblyName = GetCurrentSettings();
            var environmentFileName = $"{path}{currentAssemblyName}.env";
            Env.Load(environmentFileName);
        }

        /// <summary>
        /// Returns env-file name without extension.
        /// </summary>
        protected abstract string CurrentSettings();

        private string GetCurrentSettings() => CurrentSettings();
    }
}