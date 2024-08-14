using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardDialogViewModel 2024-08-11 01:55)
/// </summary>
public abstract partial class WizardDialogViewModel<TPayload> : ViewModelBase, IWizardViewModel,
    IRecipient<StepErrorsChangedMessage>,
    IRecipient<ManagerStepActivatedMessage>
    where TPayload : class, new()
{
    private readonly IWizardManager<TPayload> _manager;
    private readonly DefaultWizardContext<TPayload> _wizardContext;

    protected WizardDialogViewModel(IWizardManager<TPayload> manager)
    {
        _wizardContext = new DefaultWizardContext<TPayload>();
        _manager = manager;

        InitializeWizard();
        _manager.ActivateStep(_wizardContext);
    }

    protected TPayload Payload { get; private set; } = null!;

    public bool HasErrors { get; set; }

    protected virtual TPayload InitializeContext() => new TPayload();

    #region ObservableProperties

    #region property Steps
    [ObservableProperty]
    private ObservableCollection<IWizardStep> _steps;
    #endregion

    #region property ActiveStep
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Steps))]
    [NotifyPropertyChangedFor(nameof(IsNotLast))]
    private IWizardStep? _activeStep;
    #endregion

    #region  property CurrentIndex
    // [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    // [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    // [ObservableProperty]
    // private int _currentIndex;
    #endregion

    #region property IsLast and IsNotLast

    public bool IsNotLast => !ActiveStep?.IsLast ?? false;

    #endregion

    #region property FinishButtonText

    [ObservableProperty]
    private string _finishButtonText = "Finish";

    #endregion

    #region property NextButtonText

    [ObservableProperty]
    private string _nextButtonText = "Next";

    #endregion

    #region property PreviuosButtonText

    [ObservableProperty]
    private string _previousButtonText = "Previous";

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

    [RelayCommand]
    private void FinishWizard()
    {
        OnWizardFinishedExecute(_wizardContext.Payload);
        ((Window)Owner!).Close();
    }

    #endregion

    #endregion

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogViewModel 2024-08-13 01:11)
    /// </summary>
    private void InitializeWizard()
    {
        _wizardContext.Payload = InitializeContext();
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    /// <summary>
    /// // Calabonga: Summary required (WizardDialogViewModel 2024-08-13 01:11)
    /// </summary>
    public void Dispose()
    {
        _wizardContext.Payload = null;
        WeakReferenceMessenger.Default.UnregisterAll(this);
    }

    public void Receive(StepErrorsChangedMessage message)
    {
        HasErrors = message.HasErrors;
        NextStepCommand.NotifyCanExecuteChanged();
        PreviousStepCommand.NotifyCanExecuteChanged();
    }

    public void Receive(ManagerStepActivatedMessage message)
    {
        Steps = message.Steps;
        ActiveStep = message.ActiveStep;
        NextStepCommand.NotifyCanExecuteChanged();
        PreviousStepCommand.NotifyCanExecuteChanged();
    }

    public abstract void OnWizardFinishedExecute(TPayload? payload);
}