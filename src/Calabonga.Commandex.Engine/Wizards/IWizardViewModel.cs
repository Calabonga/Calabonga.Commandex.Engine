using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// Wizard ViewModel abstraction
/// </summary>
public interface IWizardViewModel : IDialog
{
    /// <summary>
    /// Returns payload model from wizard context.
    /// </summary>
    object? Payload { get; }
}
