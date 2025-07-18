using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.Engine.Zones;

/// <summary>
/// Default implementation for <see cref="IZoneViewModel"/>
/// </summary>
public abstract class ZoneViewModelBase : ViewModelBase, IZoneViewModel
{
    /// <summary>
    /// Returns reference to <see cref="IZoneManager"/> manager for current zone item ViewModel.
    /// </summary>
    public IZoneManager ZoneManager { get; set; } = null!;

    /// <summary>
    /// Deactivates current viewModel
    /// </summary>
    public virtual void OnDeactivate() { }

    /// <summary>
    /// Activates current viewModel
    /// </summary>
    public virtual void OnActivate() { }
}
