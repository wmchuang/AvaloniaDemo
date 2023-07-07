using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ItemSourceBugDemo.ViewModels;

namespace ItemSourceBugDemo.Views;

public partial class BPageView : UserControl
{
    public BPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    /// <summary>
    /// 滑动加载事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScrollViewer_OnScrollChanged(object? sender, ScrollChangedEventArgs e)
    {
        var vm = (BPageViewModel)DataContext;
        if (vm == null) return;

        var m = (ScrollViewer)sender;
        //滑动距离 偏移量
        var offsetHeight = m.Offset.Length;
        if (offsetHeight == 0) return;

        //可滚动内容的范围 减去 控件本身的高度
        var extentHeight = m.Extent.Height - (m.DesiredSize.Height * 2);

        if (offsetHeight >= extentHeight)
            vm.LoadNextPageData();
    }
}