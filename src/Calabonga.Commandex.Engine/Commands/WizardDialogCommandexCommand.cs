using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Wizards;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Commands;

/// <summary>
/// Wizard Dialog Commandex Command base class for command with some steps as wizard. Wizard command will open in dialog too.
/// </summary>
/// <typeparam name="TWizardDialogResult"></typeparam>
public abstract class WizardDialogCommandexCommand<TWizardDialogResult> : ICommandexCommand
    where TWizardDialogResult : IWizardViewModel
{
    private readonly IDialogService _dialogService;

    protected WizardDialogCommandexCommand(IDialogService dialogService) => _dialogService = dialogService;

    public abstract string CopyrightInfo { get; }

    /// <summary>
    /// Current command type
    /// </summary>
    public string TypeName => GetType().Name;

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
    /// Returns True/False indicating that's data from command will push to shell
    /// </summary>
    public virtual bool IsPushToShellEnabled => false;

    /// <summary>
    /// Wizard result
    /// </summary>
    protected IWizardViewModel? Result { get; set; }

    /// <summary>
    /// Sets result for current wizard
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    protected virtual TWizardDialogResult SetResult(TWizardDialogResult result) => result;

    /// <summary>
    /// Handler OnDialogClosed
    /// </summary>
    /// <param name="result"></param>
    private void OnClosingDialogCallback(TWizardDialogResult result) => Result = SetResult(result);

    /// <summary>
    /// Returns result when <see cref="IsPushToShellEnabled"/> enabled
    /// </summary>
    public virtual object? GetResult() => IsPushToShellEnabled ? Result?.Payload : null;

    /// <summary>
    /// Tags that describes what command created for
    /// </summary>
    public virtual string[]? Tags { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}
