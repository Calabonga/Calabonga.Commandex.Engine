namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Confirmation type UI presentation
/// </summary>
public class ConfirmationButton
{
    /// <summary>
    /// Content for button
    /// </summary>
    public object Content { get; set; } = null!;

    /// <summary>
    /// Type of the Confirmation result
    /// </summary>
    public ConfirmationType ConfirmationType { get; set; }

    public bool IsDefault { get; set; }

    public bool IsCancel { get; set; }
}
