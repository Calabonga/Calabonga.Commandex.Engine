using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default notification dialog for <see cref="LogLevel"/> notifications
/// </summary>
public partial class ConfirmationDialogResult : DefaultDialogResult
{
    [ObservableProperty]
    private ObservableCollection<ConfirmationButton> _buttons = null!;

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public override WindowStyle WindowStyle => WindowStyle.ToolWindow;

    public ConfirmationType ConfirmResult { get; set; } = ConfirmationType.Cancel;

    public override void Dispose() { }

}


