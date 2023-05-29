using Avalonia.Controls;
using Avalonia.Interactivity;
using SqliteEFDemo.ViewModels;

namespace SqliteEFDemo.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel vm;
    public MainWindow()
    {
        InitializeComponent();
        vm = new MainWindowViewModel();
        this.DataContext = vm;
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        var thingTb = this.FindControl<TextBox>("Thing");

        var s = thingTb?.Text.Trim();
        if (!string.IsNullOrEmpty(s))
        {
            vm.Add(s);
        }
    }

    private void Refresh_OnClick(object? sender, RoutedEventArgs e)
    {
        vm.Refresh();
    }
}