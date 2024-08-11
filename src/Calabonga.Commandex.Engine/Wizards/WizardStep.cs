namespace Calabonga.Commandex.Engine.Wizards;

public class WizardStep : IWizardStep
{
    public WizardStep(string name)
    {
        Name = name;
    }

    public string Name { get; }
}