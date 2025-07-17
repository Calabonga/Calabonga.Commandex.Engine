using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards.Messages;

/// <summary>
/// Message for WeakReferenceManager. Command to activate step.
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
