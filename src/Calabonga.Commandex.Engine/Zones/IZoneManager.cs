using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// ZoneManager interface
/// </summary>
public interface IZoneManager
{
    /// <summary>
    /// Executes Zone activation for generic type Content and ViewModel
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="zoneName"></param>
    OperationEmpty<ExecuteCommandexCommandException> ActivateZone<TView, TViewModel>(string zoneName)
        where TView : IZoneView
        where TViewModel : IZoneViewModel;

    /// <summary>
    /// Handler for Activating event
    /// </summary>
    public event EventHandler<ZoneItem>? Activating;

    /// <summary>
    /// Handler for Activated event
    /// </summary>
    public event EventHandler<ZoneItem>? Activated;

    /// <summary>
    /// Handler for Deactivating event
    /// </summary>
    public event EventHandler<ZoneItem>? Deactivating;

    /// <summary>
    /// Handler for Deactivated event
    /// </summary>
    public event EventHandler<ZoneItem>? Deactivated;

    /// <summary>
    /// Removes <see cref="ZoneItem"/> from zone
    /// </summary>
    /// <param name="viewModel"></param>
    void Remove(IZoneViewModel viewModel);

    /// <summary>
    /// Activates previous view for current zone
    /// </summary>
    void GoBack();

    /// <summary>
    /// Returns default zone name
    /// </summary>
    /// <returns></returns>
    string GetDefaultZoneName();
}
