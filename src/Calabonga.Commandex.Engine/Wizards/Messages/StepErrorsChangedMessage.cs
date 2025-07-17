namespace Calabonga.Commandex.Engine.Wizards.Messages;

/// <summary>
/// Message for WeakReferenceManager. Notification about errors.
/// </summary>
public class StepErrorsChangedMessage
{
    public StepErrorsChangedMessage(bool hasErrors)
    {
        HasErrors = hasErrors;
    }

    public bool HasErrors { get; }
}
