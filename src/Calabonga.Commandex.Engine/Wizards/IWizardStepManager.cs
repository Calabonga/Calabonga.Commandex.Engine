using Calabonga.Commandex.Engine.Wizards.ManagerEventArgs;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStepManager 2024-08-13 08:01)
/// </summary>
public interface IWizardStepManager
{
    void ActivateStep<T>(WizardContext<T> wizardContext);

    event EventHandler<ManagerStepActivatedArgs>? ManagerStepActivated;
}