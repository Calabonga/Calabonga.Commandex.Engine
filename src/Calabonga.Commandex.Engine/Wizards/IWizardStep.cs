namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStep 2024-08-11 07:34)
/// </summary>
/// <typeparam name="TWizardStepView"></typeparam>
/// <typeparam name="TWizardStepViewModel"></typeparam>
public interface IWizardStep<out TWizardStepView, out TWizardStepViewModel>
    where TWizardStepView : IWizardStepView
    where TWizardStepViewModel : IWizardStepViewModel
{

}