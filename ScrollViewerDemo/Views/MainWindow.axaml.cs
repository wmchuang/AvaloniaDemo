using System;
using System.Reactive.Linq;
using System.Threading.Channels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ReactiveUI;
using ScrollViewerDemo.ViewModels;

namespace ScrollViewerDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenAnyValue(x => x.ScrollViewer.CurrentAnchor)
            .Subscribe(x => { Console.WriteLine(ScrollViewer.Offset.Length); });
    }

    private void ScrollViewer_OnScrollChanged(object? sender, ScrollChangedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext;
        var scrollView = (ScrollViewer)sender;

        // ScrollViewer.RegisterAnchorCandidate();

        // var m = ScrollViewer.CurrentAnchor;
        // Console.WriteLine(ScrollViewer.CurrentAnchor?.DataContext);
        //
        // Point point = new Point(scrollView.Offset.X, scrollView.Offset.Y);
        // Point scrollPoint = point.Transform(scrollView.CurrentAnchor.TransformToVisual(scrollView).Value);
        // Point pointzero = new Point(0, 0);
        // Point scrollPointTozero = pointzero.Transform(scrollView.CurrentAnchor.TransformToVisual(scrollView).Value);
        //
        // scrollView.Offset = new Vector(scrollView.Offset.X, scrollPoint.Y + 70);

        // this.ScrollViewer.Offset = new Vector(0,100);
        // Console.WriteLine($"偏移量：{t.Offset.Length}");
        // Console.WriteLine($"可滚动内容范围：{t.Extent.Height}");
        // Console.WriteLine($"窗体高度：{t.DesiredSize.Height}");
        // Console.WriteLine($"计算后的高度：{t.Extent.Height - (t.DesiredSize.Height *2)}");
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
        
        var m = ScrollViewer.CurrentAnchor;
        Console.WriteLine(ScrollViewer.CurrentAnchor?.DataContext);

        Point point = new Point(ScrollViewer.Offset.X, ScrollViewer.Offset.Y);
        Point scrollPoint = point.Transform(((Button)sender).TransformToVisual(ScrollViewer).Value);
        
        // Point pointzero = new Point(0, 0);
        // Point scrollPointTozero = pointzero.Transform(ScrollViewer.CurrentAnchor.TransformToVisual(ScrollViewer).Value);

        ScrollViewer.Offset = new Vector(ScrollViewer.Offset.X, scrollPoint.Y);
    }
}