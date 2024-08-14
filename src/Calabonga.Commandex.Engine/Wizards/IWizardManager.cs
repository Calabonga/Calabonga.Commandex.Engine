namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardManager 2024-08-13 08:01)
/// </summary>
public interface IWizardManager<TPayload>
{
    void ActivateStep(WizardContext<TPayload> wizardContext);
}