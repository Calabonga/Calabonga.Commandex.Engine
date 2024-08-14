using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (WizardStep 2024-08-14 08:13)
/// </summary>
public class WizardStep : ObservableObject
{
    public bool IsLast { get; private set; }

    public void SetLast(bool value) => IsLast = value;
}

/// <summary>
///  // Calabonga: Summary required (IWizardStep 2024-08-12 11:03)
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
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20) 
    /// </summary>
    public bool IsActive { get; private set; }

    public bool HasErrors { get; set; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 03:13)
    /// </summary>
    public object? Content { get; private set; }

    /// <summary>
    /// Step order index for sorting
    /// </summary>
    public int OrderIndex { get; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 07:58)
    /// </summary>
    public void Deactivate()
    {
        Content = null;
        IsActive = false;
    }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 07:59)
    /// </summary>
    /// <param name="content"></param>
    public void Activate(object content)
    {
        Content = content;
        IsActive = true;
    }
}