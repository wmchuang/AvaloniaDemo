using Avalonia.Controls;

namespace DialogDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent();
           // Show();
        }

        public void Show ()
        {
            DialogHost.DialogHost.GetDialogSession("DialogHost.Identifier here")?.Close(false);
        }
    }
}