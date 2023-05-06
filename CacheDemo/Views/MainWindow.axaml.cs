using Avalonia.Controls;
using Avalonia.Interactivity;
using CacheDemo.ViewModels;

namespace CacheDemo.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel model = new MainWindowViewModel();
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = model;
    }

    private void Set_OnClick(object? sender, RoutedEventArgs e)
    {
        model.SetCache(this.Input.Text);
    }

    private void Get_OnClick(object? sender, RoutedEventArgs e)
    {
        model.GetCache();
    }
}