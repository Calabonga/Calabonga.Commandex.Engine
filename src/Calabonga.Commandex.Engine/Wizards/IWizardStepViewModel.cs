using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStepViewModel 2024-08-14 07:51)
/// </summary>
public interface IWizardStepViewModel
{
    string Title { get; }

    ObservableCollection<string> Errors { get; }

    bool HasErrors { get; }
}

/// <summary>
/// // Calabonga: Summary required (IWizardStepViewModel 2024-08-13 07:26)
/// </summary>
public interface IWizardStepViewModel<in TPayload> : IWizardStepViewModel
{
    void OnEnter(TPayload? payload);

    void OnLeave(TPayload? payload);
}