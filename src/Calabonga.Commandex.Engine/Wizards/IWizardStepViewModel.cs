using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard Step ViewModel abstraction
/// </summary>
public interface IWizardStepViewModel
{
    string Title { get; }

    ObservableCollection<string> Errors { get; }

    bool HasErrors { get; }
}

/// <summary>
/// Wizard Step View abstraction with payload (result)
/// </summary>
public interface IWizardStepViewModel<in TPayload> : IWizardStepViewModel
{
    /// <summary>
    /// Fires after step activated
    /// </summary>
    /// <param name="payload"></param>
    void OnEnter(TPayload? payload);

    /// <summary>
    /// Fires when step deactivated
    /// </summary>
    /// <param name="payload"></param>
    void OnLeave(TPayload? payload);
}
