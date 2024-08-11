using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// // Calabonga: Summary required (ViewModelBase 2024-07-31 05:55)
/// </summary>
public abstract partial class ViewModelBase : ObservableObject
{
    /// <summary>
    /// // Calabonga: Summary required (ViewModelBase 2024-07-31 05:55)
    /// </summary>
    [ObservableProperty]
    private string _title = null!;

    /// <summary>
    /// // Calabonga: Summary required (ViewModelBase 2024-07-31 05:55)
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    /// <summary>
    /// // Calabonga: Summary required (ViewModelBase 2024-07-31 05:55)
    /// </summary>
    public bool IsNotBusy => !IsBusy;
}