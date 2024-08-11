using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

public abstract class WizardDialogCommandexCommand<TWizardDialogResult> : ICommandexCommand
    where TWizardDialogResult : IWizardDialogResult
{
    private readonly IDialogService _dialogService;

    protected WizardDialogCommandexCommand(IDialogService dialogService) => _dialogService = dialogService;

    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogCommandexCommand 2024-08-11 12:43)
    /// </summary>
    public string TypeName => GetType().Name;

    public abstract string DisplayName { get; }

    public abstract string Description { get; }

    public abstract string Version { get; }

    public Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var result = _dialogService.ShowDialog<IWizardDialogView, TWizardDialogResult>(result =>
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
    private IWizardDialogResult? Result { get; set; }

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
    public object? GetResult() => IsPushToShellEnabled ? Result : null;
}
