namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard step abstraction
/// </summary>
public interface IWizardStep
{
    /// <summary>
    /// Wizard step name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Indicates a state of the step
    /// </summary>
    bool IsActive { get; }

    /// <summary>
    /// Indicates errors status
    /// </summary>
    bool HasErrors { get; set; }

    /// <summary>
    /// Content of the current step
    /// </summary>
    object? Content { get; }

    /// <summary>
    /// Order index in list of steps
    /// </summary>
    int OrderIndex { get; }

    /// <summary>
    /// Indicates that current step is last one
    /// </summary>
    bool IsLast { get; }
}

/// <summary>
/// Wizard step generic abstraction
/// </summary>
/// <typeparam name="TWizardStepView"></typeparam>
/// <typeparam name="TWizardStepViewModel"></typeparam>
public interface IWizardStep<out TWizardStepView, out TWizardStepViewModel> : IWizardStep
    where TWizardStepView : IWizardStepView
    where TWizardStepViewModel : IWizardStepViewModel
{
    /// <summary>
    /// Deactivates current step
    /// </summary>
    void Deactivate();

    /// <summary>
    /// Activates current step
    /// </summary>
    /// <param name="content"></param>
    void Activate(object content);
}
