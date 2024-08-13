using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStepViewModel 2024-08-13 07:26)
/// </summary>
public interface IWizardStepViewModel
{
    string Title { get; }

    ObservableCollection<string> Errors { get; }

    bool HasErrors { get; }


    event EventHandler<bool>? HasErrorsChanged;

    bool CanGoBack { get; }
}