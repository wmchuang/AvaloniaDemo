using System;
using Avalonia.Controls;
using ScrollViewerDemo.ViewModels;

namespace ScrollViewerDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ScrollViewer_OnScrollChanged(object? sender, ScrollChangedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext;
        var t = (ScrollViewer)sender;
        Console.WriteLine($"偏移量：{t.Offset.Length}");
        Console.WriteLine($"可滚动内容范围：{t.Extent.Height}");
        Console.WriteLine($"设计时高度：{t.DesiredSize.Height}");
        Console.WriteLine($"总高度：{t.Extent.Height - t.DesiredSize.Height}");
        if (t.Offset.Length >= t.Extent.Height - t.DesiredSize.Height - 50)
        {
            vm.Load();
        }

    }
}