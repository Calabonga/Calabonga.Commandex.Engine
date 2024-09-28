using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Engine.Extensions;

/// <summary>
/// Commandex Framework Engine extensions for <see cref="Wizard"/>
/// </summary>
public static class WizardExtensions
{
    /// <summary>
    /// Extracts types of the <see cref="IWizardStep{TWizardStepView,TWizardStepViewModel}"/><br/>
    /// relationship about <see cref="IWizardStepView"/> and <see cref="IWizardStepViewModel"/>.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Type[] GetStepTypes(this IWizardStep<IWizardStepView, IWizardStepViewModel> source)
        => source.GetType()
            .GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IWizardStep<,>))
            .SelectMany(i => i.GetGenericArguments())
            .ToArray();

    /// <summary>
    /// Deactivate all steps
    /// </summary>
    /// <param name="source"></param>
    public static void DeactivateAll(this IEnumerable<IWizardStep<IWizardStepView, IWizardStepViewModel>> source)
    {
        foreach (var step in source)
        {
            step.Deactivate();
        }
    }
}
