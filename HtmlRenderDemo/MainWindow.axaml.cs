using Avalonia.Controls;

namespace HtmlRenderDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _htmlTooltipLabel.Text = " <b>HtmlPanel 哈哈</b>";
    }
}