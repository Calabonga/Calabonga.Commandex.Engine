using Calabonga.Commandex.Engine.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardStepViewModel 2024-08-11 07:32)
/// </summary>
public abstract partial class WizardStepViewModel : ViewModelBase, IWizardStepViewModel
{
    public event EventHandler<bool>? CanLeaveChanged;

    public bool CanLeave => !Errors.Any();

    [ObservableProperty]
    private ObservableCollection<string> _errors = [];

    protected void AddError(string errorMessage)
    {
        Errors.Add(errorMessage);
        OnCanLeaveChanged(false);
    }

    protected void ResetErrors()
    {
        Errors.Clear();
        OnCanLeaveChanged(true);
    }


    protected virtual void OnCanLeaveChanged(bool e) => CanLeaveChanged?.Invoke(this, e);
}
