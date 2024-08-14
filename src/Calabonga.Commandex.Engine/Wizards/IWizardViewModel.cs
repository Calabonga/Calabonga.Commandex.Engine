using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.Engine.Wizards;

/// <summary>
/// // Calabonga: Summary required (IWizardViewModel 2024-08-11 12:04)
/// </summary>
public interface IWizardViewModel : IResult
{
    /// <summary>
    /// Returns payload model from wizard context.
    /// </summary>
    object? Payload { get; }
}