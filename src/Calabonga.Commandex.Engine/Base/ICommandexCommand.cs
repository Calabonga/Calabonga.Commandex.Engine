using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// General interface for Command implementation for Commandex
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
    /// Returns result from command
    /// </summary>
    object? GetResult();

    /// <summary>
    /// Tags that describes what command created for
    /// </summary>
    public string[]? Tags { get; }
}