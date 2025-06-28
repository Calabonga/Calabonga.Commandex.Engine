using Calabonga.Commandex.Engine.ToastNotifications.Controls;

namespace Calabonga.Commandex.Engine.ToastNotifications;

/// <summary>
/// Toast notification manager
/// </summary>
public interface INotificationManager
{
    /// <summary>
    /// Show the <see cref="NotificationType"/>
    /// </summary>
    /// <param name="content"></param>
    /// <param name="areaZone"><see cref="NotificationZone"/></param>
    /// <param name="expirationTime"></param>
    /// <param name="onClick"></param>
    /// <param name="onClose"></param>
    void Show(object content, string areaZone = "", TimeSpan? expirationTime = null, Action? onClick = null, Action? onClose = null);
}
