namespace Calabonga.Commandex.Engine.Identity;

/// <summary>
/// Identity manager for modules (commands)
/// </summary>
public interface IIdentityManager
{
    /// <summary>
    /// Shell user instance. If user is not logged in on the shell it will be null.
    /// </summary>
    ICommandexIdentity? User { get; }
}
