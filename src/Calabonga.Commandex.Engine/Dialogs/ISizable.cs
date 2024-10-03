using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Inherited object has Width and Height. For example, Window
/// </summary>
public interface ISizable
{
    /// <summary>
    /// Default value <see cref="FrameworkElement.Width"/>
    /// </summary>
    double Width { get; }

    /// <summary>
    /// Default value <see cref="FrameworkElement.Height"/>
    /// </summary>
    double Height { get; }
}