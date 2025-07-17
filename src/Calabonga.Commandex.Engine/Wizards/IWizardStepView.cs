namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard Step View abstraction
/// </summary>
public interface IWizardStepView
{
    object? DataContext { get; set; }
}
