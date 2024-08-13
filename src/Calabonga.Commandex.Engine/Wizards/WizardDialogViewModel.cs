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
public abstract partial class WizardDialogViewModel : ViewModelBase, IWizardViewModel
{
    private readonly IWizardStepManager _manager;

    protected WizardDialogViewModel(IWizardStepManager manager)
    {
        _manager = manager;
        _manager.ManagerStatusChanged += OnManagerStatusChanged;
        _manager.ManagerStepActivated += OnManagerStepActivated;

        ActivateStep(0);
    }



    #region ObservableProperties

    #region property IsValid
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    private bool _isValid;
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
    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    [ObservableProperty]
    private int _currentIndex;
    #endregion

    #endregion

    public object? Owner { get; set; }

    public ResizeMode ResizeMode => ResizeMode.NoResize;

    public SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    public WindowStyle WindowStyle => WindowStyle.ToolWindow;

    #region Commands

    #region PreviuosStepCommand
    private bool CanPreviousStep() => IsValid && Steps.Any() && CurrentIndex > 0;
    [RelayCommand(CanExecute = nameof(CanPreviousStep))]
    private void PreviousStep()
    {
        var newIndex = CurrentIndex - 1;

        if (newIndex < 0)
        {
            return;
        }

        ActivateStep(newIndex);
    }
    #endregion

    #region NextStepCommand
    private bool CanNextStep => IsValid && Steps.Any() && (CurrentIndex < Steps.Count - 1);
    [RelayCommand(CanExecute = nameof(CanNextStep))]
    private void NextStep()
    {
        var newIndex = CurrentIndex + 1;

        if (newIndex >= Steps.Count)
        {
            return;
        }

        ActivateStep(newIndex);
    }
    #endregion

    #endregion

    private void ActivateStep(int index) => _manager.ActivateStep(index);

    private void OnManagerStatusChanged(object? sender, ManagerStatusChangedArgs e) => IsValid = e.HasErrors;

    private void OnManagerStepActivated(object? sender, ManagerStepActivatedArgs e)
    {
        Steps = e.Steps;
        ActiveStep = e.ActiveStep;
        CurrentIndex = e.CurrentIndex;
    }

    public void Dispose()
    {
        _manager.ManagerStatusChanged -= OnManagerStatusChanged;
        _manager.ManagerStepActivated -= OnManagerStepActivated;
    }
}