namespace Calabonga.Commandex.Engine;

/// <summary>
/// // Calabonga: Summary required (DefaultDialogResult 2024-07-31 05:51)
/// </summary>
/// <typeparam name="T"></typeparam>
public partial class DefaultDialogResult<T> : ViewModelBase, IDialogResult
{
    /// <summary>
    /// // Calabonga: Summary required (DefaultDialogResult 2024-07-31 05:52)
    /// </summary>
    public string DialogTitle => "Default Dialog Result";

    /// <summary>
    /// // Calabonga: Summary required (DefaultDialogResult 2024-07-31 05:52)
    /// </summary>
    public T? Result { get; set; }
}