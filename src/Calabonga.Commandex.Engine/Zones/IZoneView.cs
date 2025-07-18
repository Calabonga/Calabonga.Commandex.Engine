using System.Windows;
using System.Windows.Controls;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Default interface for ZoneItem
/// </summary>
public interface IZoneView
{
    /// <summary>
    /// Represents a DataContext for <see cref="FrameworkElement"/> For example, <see cref="UserControl"/>
    /// </summary>
    object? DataContext { get; set; }
}
