using System.Windows;
using System.Windows.Controls;

namespace Calabonga.Commandex.Engine.ToastNotifications.Controls;

public class ReversibleStackPanel : StackPanel
{
    #region DependencyProperty ReverseOrder

    public bool ReverseOrder
    {
        get => (bool)GetValue(ReverseOrderProperty);
        set => SetValue(ReverseOrderProperty, value);
    }

    public static readonly DependencyProperty ReverseOrderProperty =
        DependencyProperty.Register(nameof(ReverseOrder), typeof(bool), typeof(ReversibleStackPanel), new PropertyMetadata(false));


    #endregion

    protected override Size ArrangeOverride(Size arrangeSize)
    {
        double x = 0;
        double y = 0;

        var children = ReverseOrder ? InternalChildren.Cast<UIElement>().Reverse() : InternalChildren.Cast<UIElement>();
        foreach (var child in children)
        {
            Size size;

            if (Orientation == Orientation.Horizontal)
            {
                size = new Size(child.DesiredSize.Width, Math.Max(arrangeSize.Height, child.DesiredSize.Height));
                child.Arrange(new Rect(new Point(x, y), size));
                x += size.Width;
            }
            else
            {
                size = new Size(Math.Max(arrangeSize.Width, child.DesiredSize.Width), child.DesiredSize.Height);
                child.Arrange(new Rect(new Point(x, y), size));
                y += size.Height;
            }
        }

        return Orientation == Orientation.Horizontal ? new Size(x, arrangeSize.Height) : new Size(arrangeSize.Width, y);
    }
}
