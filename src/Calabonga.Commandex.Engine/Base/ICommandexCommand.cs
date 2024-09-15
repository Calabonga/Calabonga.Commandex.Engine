using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Main interface for commandex command implementation.
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
    /// Returns result from command as object
    /// </summary>
    object? GetResult();

    /// <summary>
    ///  Tags about what the command is intended for
    /// </summary>
    string[]? Tags { get; }
}