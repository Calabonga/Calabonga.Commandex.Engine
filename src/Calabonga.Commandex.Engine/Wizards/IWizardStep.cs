namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardStep 2024-08-12 08:16)
/// </summary>
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
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 08:11)
    /// </summary>
    bool HasErrors { get; set; }

    /// <summary>
    /// // Calabonga: Summary required (IWizardStep 2024-08-12 03:12)
    /// </summary>
    object Content { get; }

    int OrderIndex { get; }

    bool IsLast { get; }
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