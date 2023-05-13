using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UserControlDemo1.ViewModels;

namespace UserControlDemo1.Views;

public partial class UserView : UserControl
{
    public UserView()
    {
        InitializeComponent();
        this.DataContext = new UserViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}