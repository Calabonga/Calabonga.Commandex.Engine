using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardDialogResultBase 2024-08-11 01:55)
/// </summary>
public abstract partial class WizardDialogResultBase : ViewModelBase, IWizardDialogResult
{
    protected WizardDialogResultBase()
    {
        Steps = new ObservableCollection<IWizardStep>();
        InitializeStepList();
        ActivateStep();
    }

    [ObservableProperty]
    private ObservableCollection<IWizardStep> _steps;

    [ObservableProperty]
    private IWizardStep? _activeStep;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    private int _currentIndex;

    public object? Owner { get; set; }

    public ResizeMode ResizeMode => ResizeMode.NoResize;

    public SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    public WindowStyle WindowStyle => WindowStyle.ToolWindow;

    public abstract List<IWizardStep> ConfigureSteps();

    #region Commands

    private bool CanPreviousStep() => CurrentIndex > 0;
    [RelayCommand(CanExecute = nameof(CanPreviousStep))]
    private void PreviousStep()
    {
        if (!Steps.Any())
        {
            return;
        }

        var newIndex = CurrentIndex - 1;

        if (newIndex < 0)
        {
            return;
        }

        CurrentIndex = newIndex;
        ActiveStep = Steps[CurrentIndex];
    }

    private bool CanNextStep => CurrentIndex < Steps.Count - 1;
    [RelayCommand(CanExecute = nameof(CanNextStep))]
    private void NextStep()
    {
        if (!Steps.Any())
        {
            return;
        }

        var newIndex = CurrentIndex + 1;

        if (newIndex > Steps.Count - 1)
        {
            return;
        }

        CurrentIndex = newIndex;
        ActiveStep = Steps[CurrentIndex];
    }


    #endregion

    private void ActivateStep(int? index = null)
    {
        if (Steps is null)
        {
            throw new WizardInvalidOperationException("Steps were not defined.");
        }

        if (index is > 0)
        {
            var stepIndex = index.Value;
            CurrentIndex = --stepIndex;
            ActiveStep = Steps[CurrentIndex];
            return;
        }

        CurrentIndex = 0;
        ActiveStep = Steps[0];
    }

    private void InitializeStepList()
    {
        var items = ConfigureSteps();
        if (items.Any())
        {
            Steps = new ObservableCollection<IWizardStep>(items);
        }
    }
}