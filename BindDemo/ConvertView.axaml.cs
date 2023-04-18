using Avalonia.Controls;

namespace BindDemo
{
    public partial class ConvertView : Window
    {
        public ConvertView ()
        {
            InitializeComponent();
            this.DataContext = new ConvertViewModel ();
        }
    }
}
