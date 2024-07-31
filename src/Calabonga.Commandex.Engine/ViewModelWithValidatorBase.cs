using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (ViewModelWithValidatorBase 2024-07-31 05:55)
/// </summary>
public abstract partial class ViewModelWithValidatorBase : ObservableValidator
{
    /// <summary>
    /// // Calabonga: Summary required (ViewModelWithValidatorBase 2024-07-31 05:55) 
    /// </summary>
    [ObservableProperty]
    private string _title = null!;

    /// <summary>
    /// // Calabonga: Summary required (ViewModelWithValidatorBase 2024-07-31 05:55)
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    /// <summary>
    /// // Calabonga: Summary required (ViewModelWithValidatorBase 2024-07-31 05:55)
    /// </summary>
    public bool IsNotBusy => !IsBusy;
}