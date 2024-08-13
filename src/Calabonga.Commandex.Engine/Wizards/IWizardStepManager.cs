using Calabonga.Commandex.Engine.Wizards.ManagerEventArgs;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStepManager 2024-08-13 08:01)
/// </summary>
public interface IWizardStepManager
{
    void ActivateStep(int index);

    event EventHandler<ManagerStatusChangedArgs>? ManagerStatusChanged;

    event EventHandler<ManagerStepActivatedArgs>? ManagerStepActivated;
}