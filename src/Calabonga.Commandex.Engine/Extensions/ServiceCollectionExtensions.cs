using Calabonga.Commandex.Engine.Dialogs;
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
    /// <typeparam name="TPayload"></typeparam>
    /// <param name="source"></param>
    /// <param name="stepName"></param>
    /// <param name="orderIndex"></param>
    public static void AddWizardStep<TStepView, TStepViewModel, TPayload>(this IServiceCollection source, string stepName, int orderIndex = 0)
        where TStepView : IWizardStepView
        where TStepViewModel : IWizardStepViewModel<TPayload>
    {
        source.AddTransient(typeof(TStepView));
        source.AddTransient(typeof(TStepViewModel));
        var step = new WizardStep<TStepView, TStepViewModel>(stepName, orderIndex);
        source.AddTransient(typeof(IWizardStep<IWizardStepView, IWizardStepViewModel<TPayload>>), _ => step);
    }

    /// <summary>
    /// Register a WizardDialogViewModel
    /// </summary>
    /// <typeparam name="TWizard"></typeparam>
    /// <param name="source"></param>
    public static void AddWizard<TWizard>(this IServiceCollection source)
        where TWizard : IWizardViewModel
        => source.AddTransient(typeof(TWizard));

    /// <summary>
    /// Register <see cref="IDialogService"/> component
    /// </summary>
    /// <param name="source"></param>
    public static void AddDialogComponent(this IServiceCollection source) => source.AddTransient<IDialogService, DialogService>();

    /// <summary>
    /// Register <see cref="IWizardManager{TPayload}"/> component
    /// </summary>
    /// <param name="source"></param>
    public static void AddWizardComponent(this IServiceCollection source)
    {
        source.AddTransient<IWizardView, Wizard>();
        source.AddTransient(typeof(IWizardManager<>), typeof(WizardManager<>));
    }
}