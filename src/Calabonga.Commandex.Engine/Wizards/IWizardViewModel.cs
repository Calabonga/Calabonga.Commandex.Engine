using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardViewModel 2024-08-11 12:04)
/// </summary>
public interface IWizardViewModel : IDialog
{
    /// <summary>
    /// Returns payload model from wizard context.
    /// </summary>
    object? Payload { get; }
}
