using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardViewModelBase 2024-08-11 01:55)
/// </summary>
public abstract partial class WizardViewModelBase : ViewModelBase, IWizardViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private List<IWizardStep<IWizardStepView, IWizardStepViewModel>> _internalSteps = new();

    protected WizardViewModelBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeModel();
        ActivateStep(0);
    }

    #region ObservableProperties

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    private bool _isValid;

    [ObservableProperty]
    private ObservableCollection<IWizardStep> _steps;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Steps))]
    private IWizardStep? _activeStep;


    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    [NotifyCanExecuteChangedFor(nameof(NextStepCommand))]
    [ObservableProperty]
    private int _currentIndex;

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

    private void ActivateStep(int index)
    {
        if (ActiveStep is not null)
        {
            var activeView = (IWizardStepView)ActiveStep.Content;
            var activeViewModel = (IWizardStepViewModel)activeView.DataContext!;
            var canLeave = activeViewModel.CanLeave;
            activeViewModel.CanLeaveChanged -= ActiveViewModel_CanLeaveChanged;

            if (!canLeave)
            {
                return;
            }
        }

        foreach (var item in _internalSteps)
        {
            item.Deactivate();
        }

        var step = _internalSteps[index];
        var types = step.GetStepTypes();
        var viewType = _serviceProvider.GetService(types[0]);
        if (viewType is not IWizardStepView view)
        {
            throw new WizardInvalidOperationException($"Unable to get View object from {nameof(IWizardStepView)}");
        }

        var viewModelType = _serviceProvider.GetService(types[1]);
        if (viewModelType is not IWizardStepViewModel viewModel)
        {
            throw new WizardInvalidOperationException($"Unable to get View object from {nameof(IWizardStepViewModel)}");
        }

        viewModel.CanLeaveChanged += ActiveViewModel_CanLeaveChanged;

        view.DataContext = viewModel;
        step.Activate(view);
        Steps = new ObservableCollection<IWizardStep>(_internalSteps);
        ActiveStep = step;
        CurrentIndex = index;
    }

    private void ActiveViewModel_CanLeaveChanged(object? sender, bool e)
    {
        IsValid = e;
    }

    private void InitializeModel()
    {
        _internalSteps = _serviceProvider.GetServices<IWizardStep<IWizardStepView, IWizardStepViewModel>>().ToList();
        Steps = new ObservableCollection<IWizardStep>(_internalSteps);
    }
}