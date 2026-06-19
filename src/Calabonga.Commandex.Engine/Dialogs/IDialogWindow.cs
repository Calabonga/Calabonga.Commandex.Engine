using System.Windows;

namespace Calabonga.Commandex.Engine.Dialogs;

/// <summary>
/// Window for dialogs. If not registered in dependency injection container then wil used default <see cref="DialogWindow"/>
/// </summary>
public interface IDialogWindow
{
    public event EventHandler Closed;

    public object? Content { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public WindowState WindowState { get; set; }

    public string Title { get; set; }

    public ResizeMode ResizeMode { get; set; }

    public SizeToContent SizeToContent { get; set; }

    public WindowStyle WindowStyle { get; set; }

    public bool? ShowDialog();

    public void InitializeComponent();
}
