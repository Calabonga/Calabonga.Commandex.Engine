using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.Engine.Settings;

/// <summary>
/// Default implementation for settings reader configuration
/// </summary>
public class DefaultSettingsReaderConfiguration : ISettingsReaderConfiguration
{
    /// <summary>
    /// Returns file name where settings stored
    /// </summary>
    /// <returns></returns>
    public string GetEnvironmentFileName()
        =>
            GetType().Assembly.GetName().Name
            ?? throw new InvalidOperationException("ISettingsReaderConfiguration reader not configured properly.");

    /// <summary>
    /// Returns file extension name for file where settings stored
    /// </summary>
    /// <returns></returns>
    public string GetExtensionFileName() => ".env";
}
