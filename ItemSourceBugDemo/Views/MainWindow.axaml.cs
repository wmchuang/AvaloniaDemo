using Avalonia.Controls;
using Avalonia.Interactivity;
using ItemSourceBugDemo.ViewModels;

namespace ItemSourceBugDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        ((MainWindowViewModel)this.DataContext).CurrentPage = new APageViewModel();
    }
    
    private void Button_OnClick1(object? sender, RoutedEventArgs e)
    {
        ((MainWindowViewModel)this.DataContext).CurrentPage = new BPageViewModel();
    }
}