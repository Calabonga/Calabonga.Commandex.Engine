using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// // Calabonga: Summary required (ICommandexCommand 2024-07-31 07:55)
/// </summary>
public interface ICommandexCommand : IDisposable
{
    /// <summary>
    /// Current command type
    /// </summary>
    string TypeName => GetType().Name;

    /// <summary>
    /// Author or copyright information
    /// </summary>
    string CopyrightInfo { get; }

    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    bool IsPushToShellEnabled { get; }

    /// <summary>
    /// Display command name in command list 
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// Brief information about what command created for
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Current command version info for identification
    /// </summary>
    string Version { get; }

    /// <summary>
    /// Executes command
    /// </summary>
    Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    /// <summary>
    /// // Calabonga: Summary required (ICommandexCommand 2024-07-31 08:03)
    /// </summary>
    object? GetResult();

    /// <summary>
    ///  Tags about what the command is intended for
    /// </summary>
    string[] Tags { get; }
}