namespace Calabonga.Commandex.Engine.Exceptions;

/// <summary>
/// // Calabonga: Summary required (NugetExtractException 2024-08-05 02:24)
/// </summary>
public class NugetExtractException : InvalidOperationException
{
    public NugetExtractException(string message) : base(message) { }

    public NugetExtractException(string message, Exception? innerException) : base(message, innerException) { }
}