using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
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
        // var vm = (MainWindowViewModel)DataContext;
        // var t = (ScrollViewer)sender;
        //
        //
        //
        // // Console.WriteLine($"偏移量：{t.Offset.Length}");
        // // Console.WriteLine($"可滚动内容范围：{t.Extent.Height}");
        // // Console.WriteLine($"窗体高度：{t.DesiredSize.Height}");
        // // Console.WriteLine($"计算后的高度：{t.Extent.Height - (t.DesiredSize.Height *2)}");
        //
        // if (t.Offset.Length >= t.Extent.Height - (t.DesiredSize.Height *2))
        // {
        //     vm.Load();
        // }
    }

    // private void Button_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var m = ScrollViewer.CurrentAnchor;
    //    this.ScrollViewer.Offset = new Vector(0,100);
    // }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        ScrollViewer.RegisterAnchorCandidate((Button)sender);

        var m = ScrollViewer.CurrentAnchor;
    }
}