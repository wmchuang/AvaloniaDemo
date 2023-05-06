using System;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;
using 线程异常捕捉.ViewModels;

namespace 线程异常捕捉.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext;
        Console.WriteLine($"主线程ID{Thread.CurrentThread.ManagedThreadId}");
        TaskClient.Run(vm.DoSomethingAsync);
    }
}