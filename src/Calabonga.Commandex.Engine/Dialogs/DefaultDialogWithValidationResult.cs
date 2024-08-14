using Calabonga.Commandex.Engine.Base;
using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// // Calabonga: Summary required (DefaultDialogResult 2024-08-02 01:48)
/// </summary>
public abstract class DefaultDialogWithValidationResult : ViewModelWithValidatorBase, IDialogResult
{
    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-07-31 05:53)
    /// </summary>
    public abstract string DialogTitle { get; }

    /// <summary>
    /// Default value <see cref="ResizeMode.NoResize"/>
    /// </summary>
    public virtual ResizeMode ResizeMode => ResizeMode.NoResize;

    /// <summary>
    /// Default value <see cref="SizeToContent.WidthAndHeight"/>
    /// </summary>
    public virtual SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public virtual WindowStyle WindowStyle => WindowStyle.ToolWindow;

    /// <summary>
    /// Dialog instance
    /// </summary>
    public object? Owner { get; set; }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public abstract void Dispose();
}