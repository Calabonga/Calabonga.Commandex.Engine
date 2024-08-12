using Calabonga.Commandex.Engine.Wizards;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Engine.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register a <see cref="IWizardStep{TWizardStepView,TWizardStepViewModel}"/>> for a <see cref="IWizardViewModel"/>
    /// </summary>
    /// <typeparam name="TStepView"></typeparam>
    /// <typeparam name="TStepViewModel"></typeparam>
    /// <param name="source"></param>
    /// <param name="stepName"></param>
    public static void AddWizardStep<TStepView, TStepViewModel>(this IServiceCollection source, string stepName)
        where TStepView : IWizardStepView
        where TStepViewModel : IWizardStepViewModel
    {
        source.AddScoped(typeof(TStepView));
        source.AddScoped(typeof(TStepViewModel));
        var step = new WizardStep<TStepView, TStepViewModel>(stepName);
        source.AddScoped(typeof(IWizardStep<IWizardStepView, IWizardStepViewModel>), _ => step);
    }

    /// <summary>
    /// Register a <see cref="WizardViewModelBase"/>
    /// </summary>
    /// <typeparam name="TWizard"></typeparam>
    /// <param name="source"></param>
    public static void AddWizard<TWizard>(this IServiceCollection source)
        where TWizard : IWizardViewModel
        => source.AddScoped(typeof(TWizard));
}