using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using Calabonga.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// // Calabonga: Summary required (DialogService 2024-08-03 07:58)
/// </summary>
public class DialogService : IDialogService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DialogService> _logger;

    public DialogService(
        IServiceProvider serviceProvider,
        ILogger<DialogService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(object dialogParameter, Action<TViewModel>? onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog
        => ShowDialogInternal<TView, TViewModel>(dialogParameter, onClosingDialogCallback);

    public OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(object dialogParameter)
        where TView : IView
        where TViewModel : IDialog
        => ShowDialogInternal<TView, TViewModel>(dialogParameter);

    public OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(TViewModel model, Action<TViewModel>? onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog
        => ShowDialogInternal<TView, TViewModel>(model, onClosingDialogCallback);

    /// <summary>
    /// // Calabonga: Summary required (IDialogService 2024-07-31 05:53)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="onClosingDialogCallback"></param>
    public OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>(Action<TViewModel> onClosingDialogCallback)
        where TView : IView
        where TViewModel : IDialog
        => ShowDialogInternal<TView, TViewModel>(null, onClosingDialogCallback);

    /// <summary>
    /// // Calabonga: Summary required (IDialogService 2024-08-03 07:56)
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public OperationEmpty<ExecuteCommandexCommandException> ShowDialog<TView, TViewModel>() where TView : IDialogView where TViewModel : IViewModel
        => ShowDialogInternal<TView, TViewModel>(null);

    public OperationEmpty<ExecuteCommandexCommandException> ShowNotification(string message)
        => ShowDialogInternal(message, LogLevel.Notification);

    public OperationEmpty<ExecuteCommandexCommandException> ShowWarning(string message)
        => ShowDialogInternal(message, LogLevel.Warning);

    public OperationEmpty<ExecuteCommandexCommandException> ShowError(string message)
        => ShowDialogInternal(message, LogLevel.Error);

    /// <summary>
    /// Show dialog with confirmation
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <param name="confirmationType"></param>
    /// <returns></returns>
    public OperationEmpty<ExecuteCommandexCommandException> ShowConfirmation(
        string message,
        Func<ConfirmationDialogResult, Task> onClosingDialogCallback,
        ConfirmationType confirmationType = ConfirmationTypes.YesNo)
        => ShowConfirmDialogInternalFunc(message, onClosingDialogCallback, confirmationType);

    /// <summary>
    /// Show dialog with confirmation
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <param name="confirmationtype"></param>
    /// <returns></returns>
    public OperationEmpty<ExecuteCommandexCommandException> ShowConfirmation(
        string message, Action<ConfirmationDialogResult> onClosingDialogCallback, ConfirmationType confirmationtype = ConfirmationTypes.YesNo)
        => ShowConfirmDialogInternalAction(message, onClosingDialogCallback, confirmationtype);

    /// <summary>
    /// Internal dialog launcher for generic dialog types.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="dialogParameter"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <returns></returns>
    private OperationEmpty<ExecuteCommandexCommandException> ShowDialogInternal<TView, TViewModel>(object? dialogParameter = null, Action<TViewModel>? onClosingDialogCallback = null)
        where TView : IView
        where TViewModel : IDialog
    {
        EventHandler closeEventHandler = null!;

        var dialog = new DialogWindow { MinWidth = 100, MinHeight = 50 };

        var handler = closeEventHandler;
        closeEventHandler = (sender, _) =>
        {
            var window = (DialogWindow)sender!;
            var userControl = (UserControl)window.Content;
            var viewModel = (TViewModel)userControl.DataContext;
            onClosingDialogCallback?.Invoke(viewModel);
            viewModel.Dispose();
            dialog.Closed -= handler;
        };

        dialog.Closed += closeEventHandler;

        try
        {
            using var scope = _serviceProvider.CreateScope();

            var viewModel = scope.ServiceProvider.GetRequiredService(typeof(TViewModel));
            var control = scope.ServiceProvider.GetRequiredService(typeof(TView));
            var userControl = (UserControl)control;
            userControl.DataContext = viewModel;
            dialog.Content = userControl;

            var viewModelResult = (IDialog)viewModel;
            viewModelResult.Owner = dialog;
            if (dialogParameter is not null && viewModelResult is IViewModel viewModelDialogResult)
            {
                viewModelDialogResult.OnParameterSet(dialogParameter);
            }

            if (viewModel is ISizable sizableViewModel)
            {
                dialog.Width = sizableViewModel.Width;
                dialog.Height = sizableViewModel.Height;
            }

            var title = viewModelResult.Title;
            dialog.Title = string.IsNullOrEmpty(title) ? "Untitled" : title;

            dialog.ResizeMode = viewModelResult.ResizeMode;
            dialog.SizeToContent = viewModelResult.SizeToContent;
            dialog.WindowStyle = viewModelResult.WindowStyle;

            dialog.InitializeComponent();
            dialog.ShowDialog();

            return Operation.Result();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return Operation.Error(new ExecuteCommandexCommandException(exception.Message, exception));
        }
    }

    /// <summary>
    /// Internal dialog launcher for primitive type (string)
    /// </summary>
    /// <param name="message"></param>
    /// <param name="type"></param>
    private OperationEmpty<ExecuteCommandexCommandException> ShowDialogInternal(string message, LogLevel type)
    {
        EventHandler closeEventHandler = null!;

        var dialog = new DialogWindow();
        var handler = closeEventHandler;

        closeEventHandler = (sender, _) =>
        {
            var window = (DialogWindow)sender!;
            var userControl = (UserControl)window.Content;
            var viewModel = (NotificationDialogResult)userControl.DataContext;
            viewModel?.Dispose();
            dialog.Closed -= handler;
        };

        dialog.Closed += closeEventHandler;

        var viewModelResult = new NotificationDialogResult
        {
            Title = message,
            Owner = dialog
        };

        var control = new NotificationDialog
        {
            DataContext = viewModelResult
        };

        dialog.ResizeMode = ((IViewModel)viewModelResult).ResizeMode;
        dialog.SizeToContent = ((IViewModel)viewModelResult).SizeToContent;
        dialog.WindowStyle = ((IViewModel)viewModelResult).WindowStyle;
        dialog.Content = control;
        dialog.Title = type.ToString();
        dialog.ShowDialog();

        return Operation.Result();
    }

    /// <summary>
    /// Internal confirmation dialog launcher for primitive type (string)
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onClosingDialogCallback"></param>
    /// <param name="confirmationType"></param>
    private OperationEmpty<ExecuteCommandexCommandException> ShowConfirmDialogInternalAction(
        string message,
        Action<ConfirmationDialogResult> onClosingDialogCallback,
        ConfirmationType confirmationType = ConfirmationTypes.YesNo)
    {
        EventHandler closeEventHandler = null!;

        var dialog = new DialogWindow();

        dialog.Content = new ConfirmationDialog { DataContext = CreateDataContext(message, confirmationType, dialog) };
        dialog.Title = "Confirmation";

        var handler = closeEventHandler;

        closeEventHandler = (sender, _) =>
        {
            var window = (DialogWindow)sender!;
            var userControl = (UserControl)window.Content;
            var viewModel = (ConfirmationDialogResult)userControl.DataContext;
            onClosingDialogCallback.Invoke(viewModel);
            viewModel.Dispose();
            dialog.Closed -= handler;
        };

        dialog.Closed += closeEventHandler;

        dialog.ShowDialog();

        return Operation.Result();
    }
    private OperationEmpty<ExecuteCommandexCommandException> ShowConfirmDialogInternalFunc(
        string message,
        Func<ConfirmationDialogResult, Task> onClosingDialogCallback,
        ConfirmationType confirmationType = ConfirmationTypes.YesNo)
    {
        EventHandler closeEventHandler = null!;

        var dialog = new DialogWindow();

        dialog.Content = new ConfirmationDialog { DataContext = CreateDataContext(message, confirmationType, dialog) };
        dialog.Title = "Confirmation";

        var handler = closeEventHandler;

        closeEventHandler = (sender, _) =>
        {
            var window = (DialogWindow)sender!;
            var userControl = (UserControl)window.Content;
            var viewModel = (ConfirmationDialogResult)userControl.DataContext;
            onClosingDialogCallback.Invoke(viewModel);
            viewModel.Dispose();
            dialog.Closed -= handler;
        };

        dialog.Closed += closeEventHandler;

        dialog.ShowDialog();

        return Operation.Result();
    }

    private static ConfirmationDialogResult CreateDataContext(string message, ConfirmationType confirmationType, DialogWindow dialog)
    {
        var items = EnumHelper<ConfirmationType>.GetValuesWithDisplayNamesByMask(confirmationType).ToList();

        var buttons = items
            .Select(x => new ConfirmationButton() { ConfirmationType = x.Key, Content = x.Value })
            .ToList();

        var viewModelResult = new ConfirmationDialogResult()
        {
            Title = message,
            Owner = dialog,
            Buttons = new ObservableCollection<ConfirmationButton>(buttons)
        };

        dialog.ResizeMode = ((IViewModel)viewModelResult).ResizeMode;
        dialog.SizeToContent = ((IViewModel)viewModelResult).SizeToContent;
        dialog.WindowStyle = ((IViewModel)viewModelResult).WindowStyle;




        return viewModelResult;
    }
}
