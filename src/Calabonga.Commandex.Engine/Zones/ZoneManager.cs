using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Zone Manager
/// </summary>
public sealed class ZoneManager : IZoneManager
{
    private readonly IMvvmObjectFactory _mvvmFactory;
    private readonly ILogger<ZoneManager> _logger;

    public ZoneManager(
        IMvvmObjectFactory mvvmFactory,
        ILogger<ZoneManager> logger)
    {
        _mvvmFactory = mvvmFactory;
        _logger = logger;
    }

    #region Events

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
    public void Remove(IZoneViewModel viewModel)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("[COMMANDEX ENGINE] Removing view with viewModel {Type} from zone", viewModel.GetType().Name);
        }

        ZoneHolder.Instance.RemoveFromZones(viewModel, OnDeactivating, OnDeactivated);
    }

    public void GoBack(bool disableFindPreviousView = false)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("[COMMANDEX ENGINE]Going back");
        }

        var getZone = ZoneHolder.Instance.GetZone(GetDefaultZoneName());
        if (!getZone.Ok)
        {
            _logger.LogError(getZone.Error, "[COMMANDEX ENGINE] {ErrorMessage}", getZone.Error.Message);

            return;
        }

        var zone = getZone.Result;
        var activeView = zone.GetActiveView();
        if (activeView is null)
        {
            _logger.LogError(getZone.Error, getZone.Error.Message);

            return;
        }

        OnDeactivating(activeView);
        activeView.DeactivateView();
        OnDeactivated(activeView);

        zone.RemoveItem(activeView);

        if (disableFindPreviousView)
        {
            return;
        }

        var lastNode = getZone.Result.Views.Last;
        if (lastNode is null)
        {
            _logger.LogError("[COMMANDEX ENGINE] Cannot find current View in the list of the nodes.");
            return;
        }

        var previous = lastNode.Previous;
        if (previous is null)
        {
            _logger.LogError("[COMMANDEX ENGINE] Cannot find previous View in the list of the nodes.");
            return;
        }

        ((Zone)zone).Activate(previous.Value, OnActivating);

        OnActivated(previous.Value);
    }

    public string GetDefaultZoneName()
    {
        return "MainZone";
    }

    #endregion

    /// <summary>
    /// Executes Zone activation for generic type Content and ViewModel
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="zoneName"></param>
    public OperationEmpty<ExecuteCommandexCommandException> ActivateZone<TView, TViewModel>(string zoneName)
        where TView : IZoneView
        where TViewModel : IZoneViewModel
    {
        var getZone = ZoneHolder.Instance.GetZone(zoneName);
        if (!getZone.Ok)
        {
            return Operation.Error(getZone.Error);
        }

        var zone = getZone.Result;

        var activeZone = zone.GetActiveView();

        if (activeZone is not null && zoneName == zone.Name)
        {
            if (typeof(TView) == activeZone.Type)
            {
                return Operation.Result();
            }

            OnDeactivating(activeZone);
            activeZone.DeactivateView();
            OnDeactivated(activeZone);
        }

        var view = _mvvmFactory.Create<TView, TViewModel>(onViewModelCreated: viewModel =>
        {
            ZoneHolder.Instance.RemoveFromZones(viewModel, OnDeactivating, OnDeactivated);

            if (viewModel is ZoneViewModelBase zoneViewModel)
            {
                zoneViewModel.ZoneManager = this;
            }
        });

        var zoneView = zone.CreateOrActivate(view, OnActivating);
        OnActivated(zoneView);

        return Operation.Result();
    }

    private void OnActivating(ZoneItem e)
    {
        if (((IZoneView)e.Content).DataContext is IZoneViewModel viewModel)
        {
            viewModel.OnActivate();
        }
        Activating?.Invoke(this, e);
    }

    private void OnActivated(ZoneItem e)
    {
        Activated?.Invoke(this, e);
    }

    private void OnDeactivating(ZoneItem e)
    {
        if (((IZoneView)e.Content).DataContext is IZoneViewModel viewModel)
        {
            viewModel.OnDeactivate();
        }

        Deactivating?.Invoke(this, e);
    }

    private void OnDeactivated(ZoneItem e)
    {
        Deactivated?.Invoke(this, e);
    }
}
