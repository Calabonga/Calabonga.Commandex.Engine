using Calabonga.Commandex.Engine.Base;
using System.Text.Json.Serialization;
using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// // Calabonga: Summary required (DefaultDialogResult 2024-08-11 10:33)
/// </summary>
public abstract class DefaultDialogResult : ViewModelBase, IDialogResult
{
    /// <summary>
    /// Default value <see cref="ResizeMode.NoResize"/>
    /// </summary>
    [JsonIgnore]
    public virtual ResizeMode ResizeMode => ResizeMode.NoResize;

    /// <summary>
    /// Default value <see cref="SizeToContent.WidthAndHeight"/>
    /// </summary>
    [JsonIgnore]
    public virtual SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    [JsonIgnore] 
    public virtual WindowStyle WindowStyle => WindowStyle.ToolWindow;

    /// <summary>
    /// Window instance that open this dialog
    /// </summary>
    [JsonIgnore]
    public object? Owner { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {

    }
}