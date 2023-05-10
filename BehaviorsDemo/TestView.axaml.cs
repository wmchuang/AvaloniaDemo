using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BehaviorsDemo;

public partial class TestView : Window
{
    public TestView()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
    public TestView(Window window)
    {
        InitializeComponent();
        this.Owner = window;
        this.WindowStartupLocation= WindowStartupLocation.CenterOwner;
        
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}