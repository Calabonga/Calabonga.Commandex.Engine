using Calabonga.Commandex.Engine.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardStepViewModel 2024-08-11 07:32)
/// </summary>
public abstract partial class WizardStepViewModel : ViewModelBase, IWizardStepViewModel
{
    public event EventHandler<bool>? HasErrorsChanged;

    public bool HasErrors => Errors.Any();

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
        HasErrorsChanged?.Invoke(this, hasErrors);
    }

    public virtual bool CanGoBack { get; } = false;
}