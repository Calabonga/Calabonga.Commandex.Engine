using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// // Calabonga: Summary required (ResultCommandexCommand 2024-07-29 09:38)
/// </summary>
public abstract class EmptyCommandexCommand : ICommandexCommand
{
    public string TypeName => GetType().Name;

    public abstract string CopyrightInfo { get; }

    public virtual bool IsPushToShellEnabled => false;

    public abstract string DisplayName { get; }

    public abstract string Description { get; }

    public abstract string Version { get; }

    public abstract Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync();

    public object? GetResult() => null;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}