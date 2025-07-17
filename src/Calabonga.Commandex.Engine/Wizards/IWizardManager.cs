namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Activates a wizard step
/// </summary>
public interface IWizardManager<TPayload> : IDisposable
{
    void ActivateStep(WizardContext<TPayload> wizardContext);
}
