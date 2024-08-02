using System.Windows;

namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (IDialogResult 2024-07-31 05:52)
/// </summary>
public interface IDialogResult
{
    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-07-31 05:53)
    /// </summary>
    string DialogTitle { get; }

    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:09)
    /// </summary>
    WindowStartupLocation WindowStartupLocation { get; }

    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:09)
    /// </summary>
    ResizeMode ResizeMode { get; }

    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:10)
    /// </summary>
    SizeToContent SizeToContent { get; }

    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:11)
    /// </summary>
    WindowStyle WindowStyle { get; }

}