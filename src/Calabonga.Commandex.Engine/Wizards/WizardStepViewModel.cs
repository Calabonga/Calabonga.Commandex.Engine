using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Wizards.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// WizardStep ViewModel abstraction with some base functionality
/// </summary>
public abstract partial class WizardStepViewModel<TPayload> : ViewModelBase, IWizardStepViewModel<TPayload>
{
    public bool HasErrors
    {
        get
        {
            return Errors.Any();
        }
    }

    [ObservableProperty]
    private ObservableCollection<string> _errors = [];

    protected void AddError(string errorMessage)
    {
        Errors.Add(errorMessage);
        OnHasErrorsChanged(true);
    }

    protected void ResetErrors()
    {
        Errors.Clear();
        OnHasErrorsChanged(false);
    }

    protected virtual void OnHasErrorsChanged(bool hasErrors)
    {
        WeakReferenceMessenger.Default.Send(new StepErrorsChangedMessage(hasErrors));
    }

    /// <summary>
    /// Indicate that wizard can go into previous step
    /// </summary>
    public virtual bool CanGoBack { get; } = false;

    public virtual void OnEnter(TPayload? payload)
    {

    }

    public virtual void OnLeave(TPayload? payload)
    {

    }
}
