namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// // Calabonga: Summary required (ExecuteCommandexCommandException 2024-08-04 07:09)
/// </summary>
public class ExecuteCommandexCommandException : InvalidOperationException
{
    public ExecuteCommandexCommandException(string message) : base(message) { }

    public ExecuteCommandexCommandException(string message, Exception? innerException) : base(message, innerException) { }
}