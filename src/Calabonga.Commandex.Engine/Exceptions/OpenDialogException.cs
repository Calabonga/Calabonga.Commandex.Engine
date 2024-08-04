namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// // Calabonga: Summary required (OpenDialogException 2024-08-04 07:09)
/// </summary>
public class OpenDialogException : InvalidOperationException
{
    public OpenDialogException(string message) : base(message) { }

    public OpenDialogException(string message, Exception? innerException) : base(message, innerException) { }
}