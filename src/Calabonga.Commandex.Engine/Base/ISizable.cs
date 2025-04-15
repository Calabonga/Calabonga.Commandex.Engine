using System.Windows;

namespace Calabonga.Commandex.Engine.Base;

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

    /// <summary>
    /// Open windows maximizes and ignore <see cref="Width"/> and <see cref="Height"/>
    /// </summary>
    bool IsMaximize { get; }
}
