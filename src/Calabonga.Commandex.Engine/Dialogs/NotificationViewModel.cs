using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default notification dialog for <see cref="LogLevel"/> notifications
/// </summary>
public partial class NotificationViewModel : DefaultDialogResult
{
    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public override WindowStyle WindowStyle => WindowStyle.ToolWindow;

    public override void Dispose() { }
}
