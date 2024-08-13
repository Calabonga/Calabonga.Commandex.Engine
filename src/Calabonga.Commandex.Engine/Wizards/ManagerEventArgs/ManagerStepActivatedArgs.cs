using System.Collections.ObjectModel;

namespace Calabonga.Commandex.Engine.Wizards.ManagerEventArgs;

/// <summary>
/// // Calabonga: Summary required (ManagerStatusChangedArgs 2024-08-13 08:18)
/// </summary>
public class ManagerStepActivatedArgs : EventArgs
{
    public ManagerStepActivatedArgs(ObservableCollection<IWizardStep> steps, IWizardStep? activeStep, int currentIndex)
    {
        Steps = steps;
        ActiveStep = activeStep;
        CurrentIndex = currentIndex;
    }

    public ObservableCollection<IWizardStep> Steps { get; }

    public IWizardStep? ActiveStep { get; }

    public int CurrentIndex { get; }

}