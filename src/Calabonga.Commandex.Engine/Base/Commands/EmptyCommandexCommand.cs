using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base.Commands;

/// <summary>
/// // Calabonga: Summary required (CommandexCommand 2024-07-29 09:38)
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
    ///  Tags about what the command is intended for
    /// </summary>
    public abstract string[]? Tags { get; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}