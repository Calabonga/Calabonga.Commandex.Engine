using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// WizardStepViewModel with validation (<see cref="ObservableValidator"/>) functionality.
/// </summary>
public abstract partial class WizardStepValidationViewModel<TPayload> : ViewModelWithValidatorBase, IWizardStepViewModel<TPayload>
{
    protected WizardStepValidationViewModel()
    {
        ErrorsChanged += OnErrorChanged;
        ValidateAllProperties();
    }

    private void OnErrorChanged(object? sender, DataErrorsChangedEventArgs e)
    {
        var hasErrors = GetErrors().Any();
        WeakReferenceMessenger.Default.Send(new StepErrorsChangedMessage(hasErrors));
    }

    [ObservableProperty]
    private ObservableCollection<string> _errors = [];

    /// <summary>
    /// Fires after step activated
    /// </summary>
    /// <param name="payload"></param>
    public virtual void OnEnter(TPayload? payload) { }

    /// <summary>
    /// Fires when step deactivated
    /// </summary>
    /// <param name="payload"></param>
    public virtual void OnLeave(TPayload? payload) { }
}
