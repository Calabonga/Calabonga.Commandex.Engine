using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using System.Diagnostics;
using System.Windows;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Zone Storage as singleton. Current holder required as storage for XAML element marked as <see cref="IZone"/> for other components placement
/// </summary>
internal sealed class ZoneHolder
{
    private readonly IList<IZone> _zones = new List<IZone>();

    /// <summary>
    /// Register a zone from attached property (XAML)
    /// </summary>
    /// <param name="element"></param>
    /// <param name="name"></param>
    public void RegisterZone(DependencyObject element, string name)
    {
        _zones.Add(new Zone(name, element));
    }

    /// <summary>
    /// Returns a zone if it registered
    /// </summary>
    /// <param name="zoneName"></param>
    /// <returns></returns>
    public Operation<IZone, ExecuteCommandexCommandException> GetZone(string zoneName)
    {
        if (string.IsNullOrEmpty(zoneName))
        {
            return Operation.Error(new ExecuteCommandexCommandException("ZoneName is not provided."));
        }

        var zone = _zones.FirstOrDefault(x => x.Name == zoneName);

        if (zone is not null)
        {
            return Operation.Result(zone);
        }

        return Operation.Error(new ExecuteCommandexCommandException($"UIElement is not found with name {zoneName}"));

    }

    /// <summary>
    /// Find zones where ViewModel is placed
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="onDeactivating"></param>
    /// <param name="onDeactivated"></param>
    /// <returns></returns>
    public void RemoveFromZones(IZoneViewModel viewModel, Action<ZoneItem> onDeactivating, Action<ZoneItem> onDeactivated)
    {
        foreach (var zone in _zones)
        {
            var itemsToRemove = new List<ZoneItem>();
            foreach (var zoneView in zone.Views)
            {
                if (((IZoneView)zoneView.Content).DataContext is not IZoneViewModel zoneViewModel)
                {
                    continue;
                }

                if (zoneViewModel.GetType() == viewModel.GetType())
                {
                    itemsToRemove.Add(zoneView);
                }
            }

            if (itemsToRemove.Any())
            {
                itemsToRemove.ForEach(x =>
                {
                    onDeactivating(x);
                    zone.RemoveItem(x);
                    onDeactivated(x);
                });
            }
        }
    }

    #region singleton

    private static readonly Lazy<ZoneHolder> Lazy = new(() => new ZoneHolder());


    private ZoneHolder() { }

    /// <summary>
    /// Instance of the <see cref="ZoneHolder"/>
    /// </summary>
    public static ZoneHolder Instance
    {
        get
        {
            return Lazy.Value;
        }
    }

    #endregion
}
