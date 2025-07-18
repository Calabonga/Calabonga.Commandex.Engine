using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Default notification dialog for <see cref="LogLevel"/> notifications
/// </summary>
public partial class NotificationDialogResult : DefaultDialogResult
{
    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public override WindowStyle WindowStyle
    {
        get
        {
            return WindowStyle.ToolWindow;
        }
    }

    public override void Dispose() { }
}
