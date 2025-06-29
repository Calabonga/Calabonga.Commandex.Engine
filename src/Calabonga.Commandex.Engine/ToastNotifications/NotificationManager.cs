using Calabonga.Commandex.Engine.ToastNotifications.Controls;
using System.Windows;
using System.Windows.Threading;

namespace Calabonga.Commandex.Engine.ToastNotifications;

/// <summary>
/// Toast notification manager
/// </summary>
public class NotificationManager : INotificationManager
{
    private readonly Dispatcher _dispatcher;
    private static readonly List<NotificationZone> Areas = new();
    private static NotificationsOverlayWindow? _window;

    public NotificationManager(Dispatcher? dispatcher = null)
    {
        dispatcher ??= Application.Current?.Dispatcher ?? Dispatcher.CurrentDispatcher;

        _dispatcher = dispatcher;
    }

    public void Show(object content, string areaName = "", TimeSpan? expirationTime = null, Action? onClick = null, Action? onClose = null)
    {
        if (!_dispatcher.CheckAccess())
        {
            _dispatcher.BeginInvoke(new Action(() => Show(content, areaName, expirationTime, onClick, onClose)));
            return;
        }

        expirationTime ??= TimeSpan.FromSeconds(3);

        if (areaName == string.Empty && _window == null)
        {
            var workArea = SystemParameters.WorkArea;

            _window = new NotificationsOverlayWindow
            {
                Left = workArea.Left,
                Top = workArea.Top,
                Width = workArea.Width,
                Height = workArea.Height
            };

            _window.Show();
        }

        foreach (var zone in Areas.Where(a => a.Name == areaName))
        {
            zone.ShowAsync(content, (TimeSpan)expirationTime, onClick, onClose).ConfigureAwait(false);
        }
    }

    internal static void AddArea(NotificationZone zone)
        => Areas.Add(zone);

    public static NotificationContent CreateInformationToast(string message, string title = "Information")
        => ToastInformation.Create(message, title);

    public static NotificationContent CreateWarningToast(string message, string title = "Warning")
        => WarningToast.Create(message, title);

    public static NotificationContent CreateErrorToast(string message, string title = "Error")
        => ErrorToast.Create(message, title);

    public static NotificationContent CreateSuccessToast(string message, string title = "Success")
        => SuccessToast.Create(message, title);
}
