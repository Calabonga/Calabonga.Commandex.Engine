using System.Windows;
using System.Windows.Controls;

namespace Calabonga.Commandex.Engine.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : UserControl, IDialogView
    {
        public ConfirmationDialog() => InitializeComponent();

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            var window = Parent as Window;
            if (window is not null)
            {
                GetModel().ConfirmResult = ConfirmationType.Cancel;
                window.DialogResult = true;
            }
            window?.Close();
        }

        private ConfirmationDialogResult GetModel() => (ConfirmationDialogResult)DataContext;
    }
}
