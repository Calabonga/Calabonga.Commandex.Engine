using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.ManagerEventArgs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardDialogViewModel 2024-08-11 01:55)
/// </summary>
public abstract partial class WizardDialogViewModel<TWizardPayload> : ViewModelBase, IWizardViewModel
    where TWizardPayload : class, new()
{
    private readonly IWizardStepManager _manager;
    private readonly EmptyWizardContext _wizardContext;

    protected WizardDialogViewModel(IWizardStepManager manager)
    {
        _wizardContext = new EmptyWizardContext();
        _manager = manager;
        _manager.ManagerStepActivated += OnManagerStepActivated;

        InitializeWizard();
        _manager.ActivateStep(_wizardContext);
    }

    protected TWizardPayload Payload { get; private set; } = null!;

    protected virtual TWizardPayload InitializeContext() => new TWizardPayload();

    #region ObservableProperties

    #region property IsValid
    // [ObservableProperty]
    //[NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    //[NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    // private bool _isValid;
    public bool HasErrors { get; set; }
    #endregion

    #region property Steps
    [ObservableProperty]
    private ObservableCollection<IWizardStep> _steps;
    #endregion

    #region property ActiveStep
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Steps))]
    private IWizardStep? _activeStep;
    #endregion

    #region  property CurrentIndex
    // [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    // [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    // [ObservableProperty]
    // private int _currentIndex;
    #endregion

    #endregion

    public object? Owner { get; set; }

    public ResizeMode ResizeMode => ResizeMode.NoResize;

    public SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    public WindowStyle WindowStyle => WindowStyle.ToolWindow;

    #region Commands

    #region PreviuosStepCommand
    private bool CanPreviousStep() => !HasErrors && Steps.Any() && _wizardContext.StepIndex > 0;
    [RelayCommand(CanExecute = nameof(CanPreviousStep))]
    private void PreviousStep()
    {
        if (_wizardContext.StepIndex - 1 < 0)
        {
            return;
        }

        _wizardContext.StepIndex -= 1;
        _manager.ActivateStep(_wizardContext);
    }
    #endregion

    #region NextStepCommand
    private bool CanNextStep => !HasErrors && Steps.Any() && (_wizardContext.StepIndex < Steps.Count - 1);
    [RelayCommand(CanExecute = nameof(CanNextStep))]
    private void NextStep()
    {
        if (_wizardContext.StepIndex + 1 >= Steps.Count)
        {
            return;
        }

        _wizardContext.StepIndex += 1;
        _manager.ActivateStep(_wizardContext);
    }
    #endregion

    #endregion

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogViewModel 2024-08-13 01:11)
    /// </summary>
    private void InitializeWizard() => _wizardContext.Payload = InitializeContext();

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogViewModel 2024-08-13 01:11)
    /// </summary>
    public void Dispose()
    {
        _manager.ManagerStepActivated -= OnManagerStepActivated;
    }

    #region EventHandlers


    private void OnManagerStepActivated(object? sender, ManagerStepActivatedArgs e)
    {
        HasErrors = e.ActiveStep!.HasErrors;
        Steps = e.Steps;
        ActiveStep = e.ActiveStep;
        NextStepCommand.NotifyCanExecuteChanged();
        PreviousStepCommand.NotifyCanExecuteChanged();
    }

    #endregion
}