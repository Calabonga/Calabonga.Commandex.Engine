namespace Calabonga.Commandex.Engine.Identity;

/// <summary>
/// User identity data for <see cref="ICommandexIdentity"/>
/// </summary>
public interface ISecureData
{
    /// <summary>
    /// Access Token
    /// </summary>
    string? AccessToken { get; set; }

    /// <summary>
    /// Token type
    /// </summary>
    string? TokenType { get; set; }

    /// <summary>
    /// Expired information
    /// </summary>
    int ExpiresIn { get; set; }

    /// <summary>
    /// Refresh token
    /// </summary>
    string? RefreshToken { get; set; }
}
