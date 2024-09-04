namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Default interface for settings reader configuration
/// </summary>
public interface ISettingsReaderConfiguration
{
    /// <summary>
    /// Returns file name where settings stored
    /// </summary>
    /// <returns></returns>
    string GetEnvironmentFileName();

    /// <summary>
    /// Returns file extension name for file where settings stored
    /// </summary>
    /// <returns></returns>
    string GetExtensionFileName();
}