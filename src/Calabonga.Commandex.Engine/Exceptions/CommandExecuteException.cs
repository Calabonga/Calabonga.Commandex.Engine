namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// // Calabonga: Summary required (OpenDialogException 2024-08-04 07:09)
/// </summary>
public class CommandExecuteException : InvalidOperationException
{
    public CommandExecuteException(string message) : base(message) { }

    public CommandExecuteException(string message, Exception? innerException) : base(message, innerException) { }
}