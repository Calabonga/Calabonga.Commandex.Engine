using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default Dialog result with <see cref="ObservableValidator"/> for view that should be used as UI for <see cref="DialogCommandexCommand{TDialogView,TDialogResult}"/>
/// </summary>
public abstract class DefaultDialogWithValidationResult : ViewModelWithValidatorBase, IViewModel, ISizable
{
    /// <summary>
    /// Default value <see cref="ResizeMode.NoResize"/>
    /// </summary>
    [JsonIgnore]
    public virtual ResizeMode ResizeMode
    {
        get
        {
            return ResizeMode.NoResize;
        }
    }

    /// <summary>
    /// Default value <see cref="SizeToContent.WidthAndHeight"/>
    /// </summary>
    [JsonIgnore]
    public virtual SizeToContent SizeToContent
    {
        get
        {
            return SizeToContent.WidthAndHeight;
        }
    }

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    [JsonIgnore]
    public virtual WindowStyle WindowStyle
    {
        get
        {
            return WindowStyle.ToolWindow;
        }
    }

    /// <summary>
    /// Default value <see cref="FrameworkElement.Width"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Width
    {
        get
        {
            return 400;
        }
    }

    /// <summary>
    /// Default value <see cref="FrameworkElement.Height"/>
    /// </summary>
    [JsonIgnore]
    public virtual double Height
    {
        get
        {
            return 300;
        }
    }

    /// <summary>
    /// Open windows maximizes and ignore <see cref="ISizable.Width"/> and <see cref="ISizable.Height"/>
    /// </summary>
    [JsonIgnore]
    public virtual bool IsMaximize
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// Dialog instance
    /// </summary>
    [JsonIgnore]
    public object? Owner { get; set; }

    /// <summary>
    /// Fired when dialog started to provide parameters from owner.
    /// </summary>
    /// <param name="parameter"></param>
    public virtual void OnParameterSet(object? parameter) { }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {

    }
}
