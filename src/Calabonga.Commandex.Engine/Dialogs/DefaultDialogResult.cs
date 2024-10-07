using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Commands;
using System.Text.Json.Serialization;
using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default Dialog result for view that should be used as UI for <see cref="DialogCommandexCommand{TDialogView,TDialogResult}"/>
/// </summary>
public abstract class DefaultDialogResult : ViewModelBase, IViewModel, ISizable
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
    /// Default value <see cref="FrameworkElement.Width"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Width => 400;

    /// <summary>
    /// Default value <see cref="FrameworkElement.Height"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Height => 300;

    /// <summary>
    /// Window instance that open this dialog
    /// </summary>
    [JsonIgnore]
    public object? Owner { get; set; }

    /// <summary>
    /// Where the instance created from dependency container this method runs to inject parameter from dialog pipeline.
    /// </summary>
    /// <param name="parameter"></param>
    public virtual void OnParameterSet(object? parameter) { }

    /// <summary>
    /// Custom dialog parameter for Developer needs
    /// </summary>
    public object? DialogParameter { get; set; }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose() { }
}
