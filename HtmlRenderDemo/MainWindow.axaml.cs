using Avalonia.Controls;

namespace HtmlRenderDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _htmlTooltipLabel.Text = "This is an <b>HtmlPanel 哈哈</b> with <span style=\"color: red\">colors</span> and links: <a href=\"http://htmlrenderer.codeplex.com/\">HTML Renderer</a>" +
                                 "<div style=\"font-size: 1.2em; padding-top: 10px;\" >If there is more text than the size of the control scrollbars will appear.</div>" +
                                 "<br/>Click me to change my <code>Text</code> property.";
    }
}