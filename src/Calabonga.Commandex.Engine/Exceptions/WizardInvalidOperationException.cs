namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// Wizard InvalidOperationException
/// </summary>
public class WizardInvalidOperationException : InvalidOperationException
{
    public WizardInvalidOperationException(string message) : base(message) { }

    public WizardInvalidOperationException(string message, Exception? innerException) : base(message, innerException) { }
}
