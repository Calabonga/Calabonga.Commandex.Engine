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
    public string TypeName => GetType().Name;

    public abstract string CopyrightInfo { get; }

    public virtual bool IsPushToShellEnabled => false;

    public abstract string DisplayName { get; }

    public abstract string Description { get; }

    public abstract string Version { get; }

    public abstract Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    protected abstract TResult? Result { get; set; }

    private void SetResult(TResult result) => Result = result;

    public object GetResult() => Result ?? new object();

    /// <summary>
    /// Tags that describes what command created for
    /// </summary>
    public virtual string[]? Tags { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}