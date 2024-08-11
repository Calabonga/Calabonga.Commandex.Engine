using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

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

    protected DialogCommandexCommand(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public string TypeName => GetType().Name;

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public abstract string Version { get; }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    private IDialogResult? Result { get; set; }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
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
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    protected virtual TDialogResult SetResult(TDialogResult result)
    {
        return result;
    }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    private void OnClosingDialogCallback(TDialogResult result)
    {
        Result = SetResult(result);
    }

    /// <summary>
    /// // Calabonga: Summary required (DialogCommandexCommand 2024-07-31 07:49)
    /// </summary>
    public object? GetResult()
    {
        return IsPushToShellEnabled ? Result : null;
    }
}