namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Dialog result interface
/// </summary>
public interface IDialogResult : IResult
{
    object? DialogParameter { get; set; }
}