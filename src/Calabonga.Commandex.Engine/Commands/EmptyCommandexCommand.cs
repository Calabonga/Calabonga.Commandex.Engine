using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// Empty Commandex Command base class for command that returns nothing to shell
/// </summary>
public abstract class EmptyCommandexCommand : ICommandexCommand
{
    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// Current command type
    /// </summary>
    public string TypeName
    {
        get
        {
            return GetType().Name;
        }
    }

    /// <summary>
    /// Author or copyright information
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Display command name in command list 
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// Brief information about what command created for
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// Current command version info for identification
    /// </summary>
    public abstract string Version { get; }

    public abstract Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    /// <summary>
    /// Returns result from command
    /// </summary>
    public virtual object? GetResult()
    {
        return null;
    }

    /// <summary>
    /// Tags that describes what command created for
    /// </summary>
    public virtual string[]? Tags { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}
