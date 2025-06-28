using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// DialogService interface
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Shows dialog with dialog parameter and closing callback
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="dialogParameter"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <returns></returns>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(object dialogParameter, Action<TViewModel>? onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog;

    /// <summary>
    /// Shows dialog with dialog parameter
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="dialogParameter"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(object dialogParameter)
        where TView : IView
        where TViewModel : IDialog;

    /// <summary>
    /// Shows dialog with dialog parameter 
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="model"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <returns></returns>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(TViewModel model, Action<TViewModel>? onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog;

    /// <summary>
    /// Shows dialog
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>()
        where TView : IDialogView
        where TViewModel : IViewModel;

    /// <summary>
    /// Shows dialog with closing callback
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="onClosingDialogCallback"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(Action<TViewModel> onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog;

    /// <summary>
    /// Opens notification dialog
    /// </summary>
    /// <param name="message"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowNotification(string message);

    /// <summary>
    /// Opens warning dialog
    /// </summary>
    /// <param name="message"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowWarning(string message);

    /// <summary>
    /// Opens error dialog
    /// </summary>
    /// <param name="message"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowError(string message);

    /// <summary>
    /// ShowAsync dialog with confirmation
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <param name="confirmationType"></param>
    /// <returns></returns>
    OperationEmpty<ExecuteCommandexCommandException> ShowConfirmation(
        string message,
        Func<ConfirmationDialogResult, Task> onClosingDialogCallback,
        ConfirmationType confirmationType = ConfirmationTypes.YesNo);

    /// <summary>
    /// ShowAsync dialog with confirmation
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <param name="confirmationType"></param>
    /// <returns></returns>
    OperationEmpty<ExecuteCommandexCommandException> ShowConfirmation(
        string message,
        Action<ConfirmationDialogResult> onClosingDialogCallback,
        ConfirmationType confirmationType = ConfirmationTypes.YesNo);
}
