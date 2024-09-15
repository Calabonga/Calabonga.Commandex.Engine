using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Wizards;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Base.Commands;

/// <summary>
/// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-14 01:21)
/// </summary>
/// <typeparam name="TWizardDialogResult"></typeparam>
public abstract class WizardDialogCommandexCommand<TWizardDialogResult> : ICommandexCommand
    where TWizardDialogResult : IWizardViewModel
{
    private readonly IDialogService _dialogService;

    protected WizardDialogCommandexCommand(IDialogService dialogService) => _dialogService = dialogService;

    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    public string TypeName => GetType().Name;

    /// <summary>
    /// // Calabonga: Summary required (ICommandexCommand 2024-07-31 08:03)
    /// </summary>
    public abstract string DisplayName { get; }

    public abstract string Description { get; }

    public abstract string Version { get; }

    public Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var result = _dialogService.ShowDialog<IWizardView, TWizardDialogResult>(result =>
        {
            if (IsPushToShellEnabled)
            {
                OnClosingDialogCallback(result);
            }
        });

        return Task.FromResult(result);
    }

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    private IWizardViewModel? Result { get; set; }

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    protected virtual TWizardDialogResult SetResult(TWizardDialogResult result) => result;

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    private void OnClosingDialogCallback(TWizardDialogResult result) => Result = SetResult(result);

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    public object? GetResult() => IsPushToShellEnabled ? Result?.Payload : null;

    /// <summary>
    ///  Tags about what the command is intended for
    /// </summary>
    public abstract string[]? Tags { get; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}