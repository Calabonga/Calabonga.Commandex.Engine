namespace Calabonga.Commandex.Engine.Wizards.ManagerEventArgs;

/// <summary>
/// // Calabonga: Summary required (cs 2024-08-12 08:40)
/// </summary>
public class StepErrorsChangedMessage
{
    public StepErrorsChangedMessage(bool hasErrors)
    {
        HasErrors = hasErrors;
    }

    public bool HasErrors { get; }
}