using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards.Messages;

/// <summary>
/// // Calabonga: Summary required (StepErrorsChangedMessage 2024-08-13 08:18)
/// </summary>
public class ManagerStepActivatedMessage
{
    public ManagerStepActivatedMessage(ObservableCollection<IWizardStep> steps, IWizardStep? activeStep)
    {
        Steps = steps;

        ActiveStep = activeStep;
    }

    public ObservableCollection<IWizardStep> Steps { get; }

    public IWizardStep? ActiveStep { get; }
}