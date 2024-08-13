namespace Calabonga.Commandex.Engine.Exceptions
{
    /// <summary>
    /// // Calabonga: Summary required (ExtractCommandexNugetException 2024-08-05 02:24)
    /// </summary>
    public class ExtractCommandexNugetException : InvalidOperationException
    {
        public ExtractCommandexNugetException(string message) : base(message) { }

        public ExtractCommandexNugetException(string message, Exception? innerException) : base(message, innerException) { }
    }
}