using System.Windows;

namespace Calabonga.Commandex.Engine
{
    public abstract class DefaultDialogViewModel : ViewModelBase, IDialogResult
    {
        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-07-31 05:53)
        /// </summary>
        public abstract string DialogTitle { get; }

        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:09)
        /// </summary>
        public virtual WindowStartupLocation WindowStartupLocation => WindowStartupLocation.CenterScreen;

        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:09)
        /// </summary>
        public virtual ResizeMode ResizeMode => ResizeMode.NoResize;

        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:10)
        /// </summary>
        public virtual SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

        /// <summary>
        /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:11)
        /// </summary>
        public virtual WindowStyle WindowStyle => WindowStyle.ToolWindow;
    }
}
