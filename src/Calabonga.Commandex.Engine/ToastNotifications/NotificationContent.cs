namespace Calabonga.Commandex.Engine.ToastNotifications;

/// <summary>
/// Notification content abstraction
/// </summary>
public abstract class NotificationContent
{
    protected NotificationContent(NotificationType type, string message, string title)
    {
        Title = title;
        Message = message;
        Type = type;
    }

    public string Title { get; }

    public string Message { get; }

    public NotificationType Type { get; }

}

internal class ToastInformation : NotificationContent
{
    private ToastInformation(NotificationType type, string message, string title)
        : base(type, message, title) { }

    public static NotificationContent Create(string message, string title = "Information")
    {
        return new ToastInformation(NotificationType.Information, message, title);
    }
}

internal class WarningToast : NotificationContent
{
    private WarningToast(NotificationType type, string message, string title)
        : base(type, message, title) { }

    public static NotificationContent Create(string message, string title = "Warning")
    {
        return new WarningToast(NotificationType.Warning, message, title);
    }
}

internal class SuccessToast : NotificationContent
{
    private SuccessToast(NotificationType type, string message, string title)
        : base(type, message, title) { }

    public static NotificationContent Create(string message, string title = "Warning")
    {
        return new SuccessToast(NotificationType.Success, message, title);
    }
}

internal class ErrorToast : NotificationContent
{
    private ErrorToast(NotificationType type, string message, string title)
        : base(type, message, title) { }

    public static NotificationContent Create(string message, string title = "Error")
    {
        return new ErrorToast(NotificationType.Error, message, title);
    }
}

