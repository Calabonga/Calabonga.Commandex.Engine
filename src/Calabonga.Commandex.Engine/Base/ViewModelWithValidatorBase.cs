using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine.Base;

/// <summary>
/// Default ViewModel for User Control Views with Title and Validation capabilities.
/// </summary>
public abstract partial class ViewModelWithValidatorBase : ObservableValidator
{
    /// <summary>
    /// Current view model Title
    /// </summary>
    [ObservableProperty]
    private string _title = null!;

    /// <summary>
    /// Indicates that current view model is busy and cannot respond to user requests.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    /// <summary>
    ///  Indicates that current view model is ready and can respond to user requests.
    /// </summary>
    public bool IsNotBusy => !IsBusy;
}