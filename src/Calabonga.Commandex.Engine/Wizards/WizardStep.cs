using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStep 2024-08-12 11:03)
/// </summary>
/// <typeparam name="TWizardStepView"></typeparam>
/// <typeparam name="TWizardStepViewModel"></typeparam>
public class WizardStep<TWizardStepView, TWizardStepViewModel>
    : ObservableObject, IWizardStep<TWizardStepView, TWizardStepViewModel>
    where TWizardStepView : IWizardStepView
    where TWizardStepViewModel : IWizardStepViewModel
{
    public WizardStep(string name)
    {
        Name = name;
    }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20) 
    /// </summary>
    public bool IsActive { get; private set; }

    public bool HasErrors { get; private set; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 03:13)
    /// </summary>
    public object? Content { get; private set; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 07:58)
    /// </summary>
    public void Deactivate()
    {
        Content = null;
        IsActive = false;
    }

    // Calabonga: Summary required (IWizardStep 2024-08-12 07:59)
    public void Activate(object content)
    {
        Content = content;
        IsActive = true;
    }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    /// <param name="value"></param>
    public void UpdateHasErrors(bool value) => HasErrors = value;
}