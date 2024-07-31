namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (IDbConnectionFactory 2024-07-26 09:17)
/// </summary>
public interface IDbConnectionFactory
{
    /// <summary>
    /// // Calabonga: Summary required (IDbConnectionFactory 2024-07-31 05:52)
    /// </summary>
    string Description { get; }
}

/// <summary>
/// // Calabonga: Summary required (IDbConnectionFactory 2024-07-26 09:14)
/// </summary>
/// <typeparam name="TConnection"></typeparam>
public interface IDbConnectionFactory<out TConnection> : IDbConnectionFactory
{
    /// <summary>
    /// // Calabonga: Summary required (IDbConnectionFactory 2024-07-31 05:53)
    /// </summary>
    /// <param name="connectionString"></param>
    /// <returns>new instance of the connection</returns>
    TConnection CreateConnection(string connectionString);
}

/// <summary>
/// // Calabonga: Summary required (IDbConnectionFactory 2024-07-26 09:14)
/// </summary>
/// <typeparam name="TConnection"></typeparam>
/// <typeparam name="TParameters"></typeparam>
public interface IDbConnectionFactory<out TConnection, in TParameters> : IDbConnectionFactory
{
    /// <summary>
    /// // Calabonga: Summary required (IDbConnectionFactory 2024-07-31 05:53)
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="credential"></param>
    /// <returns></returns>
    TConnection CreateConnection(string connectionString, TParameters credential);
}