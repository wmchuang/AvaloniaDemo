using Avalonia.Controls;

namespace D3DDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Renderer.Diagnostics.DebugOverlays = RendererDebugOverlays.Fps;
    }
}