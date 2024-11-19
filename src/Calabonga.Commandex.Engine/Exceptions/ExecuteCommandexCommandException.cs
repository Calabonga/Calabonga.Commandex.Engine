namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// Execute operation InvalidOperationException
/// </summary>
public class ExecuteCommandexCommandException : InvalidOperationException
{
    public ExecuteCommandexCommandException(string message) : base(message) { }

    public ExecuteCommandexCommandException(string message, Exception? innerException) : base(message, innerException) { }
}
