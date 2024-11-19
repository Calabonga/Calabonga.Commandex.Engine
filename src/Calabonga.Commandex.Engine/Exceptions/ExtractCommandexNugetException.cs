namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// Extracting operation InvalidOperationException
/// </summary>
public class ExtractCommandexNugetException : InvalidOperationException
{
    public ExtractCommandexNugetException(string message) : base(message) { }

    public ExtractCommandexNugetException(string message, Exception? innerException) : base(message, innerException) { }
}
