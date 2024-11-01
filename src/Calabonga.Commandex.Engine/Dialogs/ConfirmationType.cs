using System.ComponentModel.DataAnnotations;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Confirm dialog result type
/// </summary>
[Flags]
public enum ConfirmationType
{
    [Display(Name = "Yes")]
    Yes = 1,

    [Display(Name = "No")]
    No = 1 << 1,

    [Display(Name = "OK")]
    Ok = 1 << 2,

    [Display(Name = "Cancel")]
    Cancel = 1 << 3,

    [Display(Name = "Mey be")]
    MayBe = 1 << 4,

    [Display(Name = "I don't know")]
    IDontKnow = 1 << 5
}

/// <summary>
/// Enum flag helper
/// </summary>
public static class ConfirmationTypes
{
    public const ConfirmationType OkCancel = ConfirmationType.Ok | ConfirmationType.Cancel;
    public const ConfirmationType YesNo = ConfirmationType.Yes | ConfirmationType.No;
    public const ConfirmationType YesNoCancel = ConfirmationType.Yes | ConfirmationType.No | ConfirmationType.Cancel;
    public const ConfirmationType YesNoIDontKnow = ConfirmationType.Yes | ConfirmationType.No | ConfirmationType.IDontKnow;
    public const ConfirmationType YesNoMayBe = ConfirmationType.Yes | ConfirmationType.No | ConfirmationType.MayBe;
}
