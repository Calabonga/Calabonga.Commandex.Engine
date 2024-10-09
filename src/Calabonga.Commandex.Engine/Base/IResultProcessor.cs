namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Processor for <see cref="ICommandexCommand"/> result transformation for user-friendly consuming.
/// </summary>
public interface IResultProcessor
{
    /// <summary>
    /// Postprocessing result from commandex command 
    /// </summary>
    /// <param name="command"></param>
    void ProcessCommand(ICommandexCommand command);
}
