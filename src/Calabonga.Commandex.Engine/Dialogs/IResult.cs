using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs
{
    /// <summary>
    /// // Calabonga: Summary required (IWizardViewModel 2024-08-11 01:38)
    /// </summary>
    public interface IResult : IDisposable
    {
        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-07-31 05:53)
        /// </summary>
        string Title { get; }

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

        /// <summary>
        /// Dialog instance
        /// </summary>
        object? Owner { get; set; }
    }
}