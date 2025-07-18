﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Calabonga.Commandex.Engine.ToastNotifications.Controls;

[TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
public class Notification : ContentControl
{
    private TimeSpan _closingAnimationTime = TimeSpan.Zero;

    static Notification()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Notification), new FrameworkPropertyMetadata(typeof(Notification)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var closeButton = GetTemplateChild("PART_CloseButton") as Button;
        if (closeButton != null)
        {
            closeButton.Click += OnCloseButtonOnClick;
        }

        var storyboards = Template.Triggers.OfType<EventTrigger>().FirstOrDefault(t => t.RoutedEvent == NotificationCloseInvokedEvent)?.Actions.OfType<BeginStoryboard>().Select(a => a.Storyboard);
        _closingAnimationTime = new TimeSpan(storyboards?.Max(s => Math.Min((s.Duration.HasTimeSpan ? s.Duration.TimeSpan + (s.BeginTime ?? TimeSpan.Zero) : TimeSpan.MaxValue).Ticks, s.Children.Select(ch => ch.Duration.TimeSpan + (s.BeginTime ?? TimeSpan.Zero)).Max().Ticks)) ?? 0);

    }

    public bool IsClosing { get; set; }

    public static readonly RoutedEvent NotificationCloseInvokedEvent = EventManager.RegisterRoutedEvent(
        "NotificationCloseInvoked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Notification));

    public static readonly RoutedEvent NotificationClosedEvent = EventManager.RegisterRoutedEvent(
        "NotificationClosed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Notification));


    public event RoutedEventHandler NotificationCloseInvoked
    {
        add
        {
            AddHandler(NotificationCloseInvokedEvent, value);
        }
        remove
        {
            RemoveHandler(NotificationCloseInvokedEvent, value);
        }
    }

    public event RoutedEventHandler NotificationClosed
    {
        add
        {
            AddHandler(NotificationClosedEvent, value);
        }
        remove
        {
            RemoveHandler(NotificationClosedEvent, value);
        }
    }

    public static bool GetCloseOnClick(DependencyObject obj)
    {
        return (bool)obj.GetValue(CloseOnClickProperty);
    }

    public static void SetCloseOnClick(DependencyObject obj, bool value)
    {
        obj.SetValue(CloseOnClickProperty, value);
    }

    public static readonly DependencyProperty CloseOnClickProperty = DependencyProperty.RegisterAttached(
        "CloseOnClick",
        typeof(bool),
        typeof(Notification),
        new FrameworkPropertyMetadata(false, CloseOnClickChanged));

    private static void CloseOnClickChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        var button = dependencyObject as Button;
        if (button == null)
        {
            return;
        }

        var value = (bool)dependencyPropertyChangedEventArgs.NewValue;

        if (value)
        {
            button.Click += (sender, args) =>
            {
                var notification = VisualTreeExtensions.GetParent<Notification>(button);
                notification?.Close();
            };
        }
    }

    private void OnCloseButtonOnClick(object sender, RoutedEventArgs args)
    {
        var button = sender as Button;
        if (button == null)
        {
            return;
        }

        button.Click -= OnCloseButtonOnClick;
        Close();
    }

    public async void Close()
    {
        try
        {
            if (IsClosing)
            {
                return;
            }

            IsClosing = true;

            RaiseEvent(new RoutedEventArgs(NotificationCloseInvokedEvent));
            await Task.Delay(_closingAnimationTime);
            RaiseEvent(new RoutedEventArgs(NotificationClosedEvent));
        }
        catch
        {
            // ignore
        }
    }
}
