using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

public interface IWizardStepViewModel
{
    string Title { get; }

    ObservableCollection<string> Errors { get; }

    bool HasErrors { get; }

    bool CanGoBack { get; }
}

/// <summary>
/// // Calabonga: Summary required (IWizardStepViewModel 2024-08-13 07:26)
/// </summary>
public interface IWizardStepViewModel<in TPayload> : IWizardStepViewModel
{
    void Initialize(TPayload? payload);
}