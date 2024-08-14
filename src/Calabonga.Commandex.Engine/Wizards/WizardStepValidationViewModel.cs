using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardStepViewModel 2024-08-11 07:32)
/// </summary>
public abstract partial class WizardStepValidationViewModel<TPayload> : ViewModelWithValidatorBase, IWizardStepViewModel<TPayload>
{
    public WizardStepValidationViewModel() => ErrorsChanged += OnErrorChanged;

    private void OnErrorChanged(object? sender, DataErrorsChangedEventArgs e)
    {
        var hasErrors = GetErrors().Any();
        WeakReferenceMessenger.Default.Send(new StepErrorsChangedMessage(hasErrors));
    }

    [ObservableProperty]
    private ObservableCollection<string> _errors = [];

    public virtual void OnEnter(TPayload? payload) { }

    public virtual void OnLeave(TPayload? payload) { }
}