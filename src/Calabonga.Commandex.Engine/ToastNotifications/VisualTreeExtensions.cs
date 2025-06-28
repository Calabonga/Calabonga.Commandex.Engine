using System.Windows;
using System.Windows.Media;

namespace Calabonga.Commandex.Engine.ToastNotifications;

internal static class VisualTreeExtensions
{
    public static T? GetParent<T>(DependencyObject child) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(child);

        return parent switch
        {
            null => null,
            T tParent => tParent,
            _ => GetParent<T>(parent)
        };
    }
}
