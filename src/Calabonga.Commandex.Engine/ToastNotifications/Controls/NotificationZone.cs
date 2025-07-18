using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Calabonga.Commandex.Engine.ToastNotifications.Controls;

public class NotificationZone : Control
{
    public NotificationZone()
    {
        NotificationManager.AddArea(this);
    }

    static NotificationZone()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationZone), new FrameworkPropertyMetadata(typeof(NotificationZone)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var itemsControl = GetTemplateChild("PART_Items") as Panel;
        _items = itemsControl?.Children;
    }

    #region DependencyProperty Position

    public NotificationPosition Position
    {
        get
        {
            return (NotificationPosition)GetValue(PositionProperty);
        }
        set
        {
            SetValue(PositionProperty, value);
        }
    }

    public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(
        nameof(Position),
        typeof(NotificationPosition),
        typeof(NotificationZone),
        new PropertyMetadata(NotificationPosition.BottomRight));

    #endregion

    #region DependencyProperty ItemsCountMax

    public int ItemsCountMax
    {
        get
        {
            return (int)GetValue(ItemsCountMaxProperty);
        }
        set
        {
            SetValue(ItemsCountMaxProperty, value);
        }
    }

    public static readonly DependencyProperty ItemsCountMaxProperty = DependencyProperty.Register(
        nameof(ItemsCountMax),
        typeof(int),
        typeof(NotificationZone),
        new PropertyMetadata(int.MaxValue));

    private IList? _items;

    #endregion

    public async Task ShowAsync(object content, TimeSpan expirationTime, Action? onClick, Action? onClose)
    {
        var notification = new Notification
        {
            Content = content
        };

        notification.MouseLeftButtonDown += (sender, args) =>
        {
            if (onClick != null)
            {
                onClick.Invoke();
                (sender as Notification)?.Close();
            }
        };
        notification.NotificationClosed += (sender, args) => onClose?.Invoke();
        notification.NotificationClosed += OnNotificationClosed;

        if (!IsLoaded)
        {
            return;
        }

        var w = Window.GetWindow(this);
        if (w is not null)
        {
            var x = PresentationSource.FromVisual(w);
            if (x == null)
            {
                return;
            }
        }

        if (_items != null)
        {
            lock (_items)
            {
                _items.Add(notification);

                if (_items.OfType<Notification>().Count(i => !i.IsClosing) > ItemsCountMax)
                {
                    _items.OfType<Notification>().First(i => !i.IsClosing).Close();
                }
            }
        }

        if (expirationTime == TimeSpan.MaxValue)
        {
            return;
        }

        await Task.Delay(expirationTime);

        notification.Close();
    }

    private void OnNotificationClosed(object sender, RoutedEventArgs routedEventArgs)
    {
        var notification = sender as Notification;
        _items?.Remove(notification);
    }
}
