using System.Security.Principal;

namespace Calabonga.Commandex.Engine.Identity;

/// <summary>
/// Commandex identity for commands modules
/// </summary>
public interface ICommandexIdentity : IIdentity
{
    /// <summary>
    /// AuthenticationToken for access to server
    /// </summary>
    ISecureData? SecureData { get; }
}
