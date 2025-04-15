namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard context with soma payload
/// </summary>
public abstract class WizardContext<TPayload>
{
    public int StepIndex { get; set; }

    public TPayload? Payload { get; set; }
}
