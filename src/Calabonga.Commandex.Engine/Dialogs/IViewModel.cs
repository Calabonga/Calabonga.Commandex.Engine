using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Dialog result interface
/// </summary>
public interface IViewModel : IDialog
{
    /// <summary>
    /// Set parameter from <see cref="IDialogService"/>
    /// </summary>
    /// <param name="parameter"></param>
    void OnParameterSet(object? parameter);
}
