namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// // Calabonga: Summary required (ExtractCommandexNugetException 2024-08-05 02:24)
/// </summary>
public class WizardInvalidOperationException : InvalidOperationException
{
    public WizardInvalidOperationException(string message) : base(message) { }

    public WizardInvalidOperationException(string message, Exception? innerException) : base(message, innerException) { }
}