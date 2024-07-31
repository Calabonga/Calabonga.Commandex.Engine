namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (IDialogService 2024-07-29 04:10)
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// // Calabonga: Summary required (IDialogService 2024-07-31 05:53)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="onClosingDialogCallback"></param>
    void ShowDialog<TView, TViewModel>(Action<TViewModel> onClosingDialogCallback)
        where TView : IDialogView
        where TViewModel : IDialogResult;

    /// <summary>
    /// Opens notification dialog
    /// </summary>
    /// <param name="message"></param>
    void ShowNotification(string message);

    /// <summary>
    /// Opens warning dialog
    /// </summary>
    /// <param name="message"></param>
    void ShowWarning(string message);

    /// <summary>
    /// Opens error dialog
    /// </summary>
    /// <param name="message"></param>
    void ShowError(string message);
}