using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default generic interface for command result
/// </summary>
public interface IResult : IDisposable
{
    /// <summary>
    /// Dialog result title
    /// </summary>
    string Title { get; }

    /// <summary>
    /// XAML Window ResizeMode
    /// </summary>
    ResizeMode ResizeMode { get; }

    /// <summary>
    /// XAML Window SizeToContent
    /// </summary>
    SizeToContent SizeToContent { get; }

    /// <summary>
    /// XAML Window WindowStyle
    /// </summary>
    WindowStyle WindowStyle { get; }

    /// <summary>
    /// Dialog instance
    /// </summary>
    object? Owner { get; set; }
}