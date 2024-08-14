using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// // Calabonga: Summary required (IDialogService 2024-07-29 04:10)
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// // Calabonga: Summary required (IDialogService 2024-08-03 07:56)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>()
        where TView : IDialogView
        where TViewModel : IDialogResult;

    /// <summary>
    /// // Calabonga: Summary required (IDialogService 2024-07-31 05:53)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="onClosingDialogCallback"></param>
    OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(Action<TViewModel> onClosingDialogCallback)
        where TView : IView
        where TViewModel : IResult;

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
}