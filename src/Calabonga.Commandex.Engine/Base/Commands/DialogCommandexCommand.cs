using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base.Commands;

/// <summary>
/// // Calabonga: Summary required (DialogCommandexCommand 2024-07-30 07:14)
/// </summary>
/// <typeparam name="TDialogView"></typeparam>
/// <typeparam name="TDialogResult"></typeparam>
public abstract class DialogCommandexCommand<TDialogView, TDialogResult> : ICommandexCommand
    where TDialogView : IDialogView
    where TDialogResult : IDialogResult
{
    private readonly IDialogService _dialogService;

    protected DialogCommandexCommand(IDialogService dialogService) => _dialogService = dialogService;

    /// <summary>
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

    /// <summary>
    /// Current command type
    /// </summary>
    public string TypeName => GetType().Name;

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

    /// <summary>
    /// Internal dialog result
    /// </summary>
    private IDialogResult? Result { get; set; }

    /// <summary>
    /// Executes command
    /// </summary>
    public Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var result = _dialogService.ShowDialog<TDialogView, TDialogResult>(result =>
        {
            if (IsPushToShellEnabled)
            {
                OnClosingDialogCallback(result);
            }
        });

        return Task.FromResult(result);
    }

    /// <summary>
    /// Sets current command result for Shell or other command
    /// </summary>
    /// <param name="result"></param>
    protected virtual TDialogResult SetResult(TDialogResult result) => result;

    /// <summary>
    /// Handler OnDialogClosed
    /// </summary>
    private void OnClosingDialogCallback(TDialogResult result) => Result = SetResult(result);

    /// <summary>
    /// Returns result when <see cref="IsPushToShellEnabled"/> enabled
    /// </summary>
    public object? GetResult() => IsPushToShellEnabled ? Result : null;

    /// <summary>
    ///  Tags about what the command is intended for
    /// </summary>
    public abstract string[]? Tags { get; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}