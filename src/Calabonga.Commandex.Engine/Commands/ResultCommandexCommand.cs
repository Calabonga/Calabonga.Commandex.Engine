using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// Result Commandex Command base class for command that should return some result to shell.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public abstract class ResultCommandexCommand<TResult> : ICommandexCommand
{
    /// <summary>
    /// Current command type
    /// </summary>
    public string TypeName => GetType().Name;

    /// <summary>
    /// Author or copyright information
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

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

    /// <summary>
    /// Executes command
    /// </summary>
    public abstract Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    /// <summary>
    /// Current command result
    /// </summary>
    protected abstract TResult? Result { get; set; }

    /// <summary>
    /// Sets command result
    /// </summary>
    /// <param name="result"></param>
    private void SetResult(TResult result)
    {
        Result = result;
    }

    /// <summary>
    /// Returns result from command
    /// </summary>
    public virtual object? GetResult()
    {
        return Result;
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
