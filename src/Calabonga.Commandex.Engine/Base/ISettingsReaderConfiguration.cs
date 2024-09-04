namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Default interface for settings reader configuration
/// </summary>
public interface ISettingsReaderConfiguration
{
    /// <summary>
    /// Returns file name where settings stored
    /// </summary>
    string GetEnvironmentFileName(Type type);

    /// <summary>
    /// Returns file extension name for file where settings stored
    /// </summary>
    string GetExtensionFileName();
}
