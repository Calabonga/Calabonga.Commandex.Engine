using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Wizards;

public interface IWizardStep
{
    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    string Name { get; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20) 
    /// </summary>
    bool IsActive { get; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 03:12)
    /// </summary>
    object Content { get; }
}

/// <summary>
/// // Calabonga: Summary required (IWizardStep 2024-08-11 07:34)
/// </summary>
/// <typeparam name="TWizardStepView"></typeparam>
/// <typeparam name="TWizardStepViewModel"></typeparam>
public interface IWizardStep<out TWizardStepView, out TWizardStepViewModel> : IWizardStep
    where TWizardStepView : IWizardStepView
    where TWizardStepViewModel : IWizardStepViewModel
{
    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    void Deactivate();

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 04:02) 
    /// </summary>
    /// <param name="content"></param>
    void Activate(object content);
}

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

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 03:13)
    /// </summary>
    public object? Content { get; private set; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 02:20)
    /// </summary>
    /// <param name="content"></param>
    /// <param name="value"></param>
    public void SetActive(object? content, bool value = false)
    {
        IsActive = value;
        Content = content;
    }

    public void Deactivate()
    {
        Content = null;
        IsActive = false;
    }

    public void Activate(object content)
    {
        Content = content;
        IsActive = true;
    }
}