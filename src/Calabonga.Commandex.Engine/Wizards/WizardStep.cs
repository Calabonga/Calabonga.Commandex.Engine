using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard Step observable object
/// </summary>
public class WizardStep : ObservableObject
{
    public bool IsLast { get; private set; }

    public void SetLast(bool value)
    {
        IsLast = value;
    }
}

/// <summary>
/// Wizard Step generic observable object. Implementation <see cref="IWizardStep{TWizardStepView,TWizardStepViewModel}"/> interface.
/// </summary>
/// <typeparam name="TWizardStepView"></typeparam>
/// <typeparam name="TWizardStepViewModel"></typeparam>
public class WizardStep<TWizardStepView, TWizardStepViewModel>
    : WizardStep, IWizardStep<TWizardStepView, TWizardStepViewModel>
    where TWizardStepView : IWizardStepView
    where TWizardStepViewModel : IWizardStepViewModel
{
    public WizardStep(string name, int orderIndex)
    {
        Name = name;
        OrderIndex = orderIndex;
    }

    /// <summary>
    /// Wizard step name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Indicates a state of the step
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Indicates errors status
    /// </summary>
    public bool HasErrors { get; set; }

    /// <summary>
    /// Content of the current step
    /// </summary>
    public object? Content { get; private set; }

    /// <summary>
    /// Step order index for sorting
    /// </summary>
    public int OrderIndex { get; }

    /// <summary>
    /// Deactivates current step
    /// </summary>
    public void Deactivate()
    {
        Content = null;
        IsActive = false;
    }

    /// <summary>
    /// Activates current step
    /// </summary>
    /// <param name="content"></param>
    public void Activate(object content)
    {
        Content = content;
        IsActive = true;
    }
}
