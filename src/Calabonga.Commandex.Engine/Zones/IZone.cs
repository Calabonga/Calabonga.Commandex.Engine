namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Zone for content
/// </summary>
public interface IZone
{
    /// <summary>
    /// Zone name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Views in the current zone
    /// </summary>
    LinkedList<ZoneItem> Views { get; }

    /// <summary>
    /// Activates <see cref="IZoneView"/> already exists in the current zone or
    /// Creates a new instance of the view and activate it.
    /// </summary>
    /// <typeparam name="TZoneView"></typeparam>
    /// <param name="view"></param>
    /// <param name="onActivating"></param>
    /// <returns></returns>
    ZoneItem CreateOrActivate<TZoneView>(TZoneView view, Action<ZoneItem> onActivating) where TZoneView : IZoneView;

    /// <summary>
    /// Returns Active view from the views for current Zone
    /// </summary>
    /// <returns></returns>
    ZoneItem? GetActiveZoneItem();

    /// <summary>
    /// Removes <see cref="ZoneItem"/>
    /// </summary>
    /// <param name="zoneItem"></param>
    void RemoveItem(ZoneItem zoneItem);
}
