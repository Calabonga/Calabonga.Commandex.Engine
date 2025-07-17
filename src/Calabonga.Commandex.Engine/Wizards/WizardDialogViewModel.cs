using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard dialog default ViewModel
/// </summary>
public abstract partial class WizardDialogViewModel<TPayload> : ViewModelBase, IWizardViewModel, ISizable,
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

    protected abstract void OnWizardFinishedExecute(TPayload? payload);

    #region ObservableProperties

    #region property Steps
    [ObservableProperty]
    private ObservableCollection<IWizardStep>? _steps;
    #endregion

    #region property CanDoNextStep

    /// <summary>
    /// Property CanDoNextStep
    /// </summary>
    [ObservableProperty] private bool _canDoNextStep;

    #endregion

    #region property CanDoPreviousStep

    /// <summary>
    /// Property CanDoPreviousStep
    /// </summary>
    [ObservableProperty] private bool _canDoPreviousStep = true;

    #endregion

    #region property ActiveStep
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Steps))]
    [NotifyPropertyChangedFor(nameof(IsNotLast))]
    private IWizardStep? _activeStep;
    #endregion

    #region property IsLast and IsNotLast

    public bool IsNotLast
    {
        get
        {
            return !ActiveStep?.IsLast ?? false;
        }
    }

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

    #region Properties

    public object? Owner { get; set; }

    public virtual ResizeMode ResizeMode
    {
        get
        {
            return ResizeMode.NoResize;
        }
    }

    public virtual SizeToContent SizeToContent
    {
        get
        {
            return SizeToContent.Manual;
        }
    }

    public virtual WindowStyle WindowStyle
    {
        get
        {
            return WindowStyle.ToolWindow;
        }
    }

    /// <summary>
    /// Default value <see cref="FrameworkElement.Width"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Width
    {
        get
        {
            return 400;
        }
    }

    /// <summary>
    /// Default value <see cref="FrameworkElement.Height"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Height
    {
        get
        {
            return 300;
        }
    }

    public virtual bool IsMaximize
    {
        get
        {
            return false;
        }
    }

    #endregion

    #region Commands

    #region PreviuosStepCommand
    private bool CanPreviousStep()
    {
        return Steps is not null && CanDoPreviousStep && Steps.Any() && _wizardContext.StepIndex > 0;
    }

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
    private bool CanNextStep
    {
        get
        {
            return Steps is not null && CanDoNextStep && Steps.Any() && (_wizardContext.StepIndex < Steps.Count - 1);
        }
    }

    [RelayCommand(CanExecute = nameof(CanNextStep))]
    private void NextStep()
    {
        if (_wizardContext.StepIndex + 1 >= Steps?.Count)
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

    protected virtual TPayload InitializeContext()
    {
        return new TPayload();
    }

    /// <summary>
    /// Disposes current ViewModel
    /// </summary>
    public void Dispose()
    {
        WeakReferenceMessenger.Default.UnregisterAll(this);
        _manager.Dispose();
    }

    /// <summary>
    /// Receives a given <typeparamref name="TMessage" /> message instance.
    /// </summary>
    /// <param name="message">The message being received.</param>
    public void Receive(StepErrorsChangedMessage message)
    {
        CanDoNextStep = !message.HasErrors;
        NextStepCommand.NotifyCanExecuteChanged();
        PreviousStepCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Receives a given <typeparamref name="TMessage" /> message instance.
    /// </summary>
    /// <param name="message">The message being received.</param>
    public void Receive(ManagerStepActivatedMessage message)
    {
        Steps = message.Steps;
        ActiveStep = message.ActiveStep;
        NextStepCommand.NotifyCanExecuteChanged();
        PreviousStepCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Wizard initializer
    /// </summary>
    private void InitializeWizard()
    {
        _wizardContext.Payload = InitializeContext();
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    /// <summary>
    /// Returns payload model from wizard context.
    /// </summary>
    public object? Payload
    {
        get
        {
            return _wizardContext.Payload;
        }
    }
}
