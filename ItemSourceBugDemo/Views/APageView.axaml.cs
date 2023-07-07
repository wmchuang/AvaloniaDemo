using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ItemSourceBugDemo.Views;

public partial class APageView : UserControl
{
    public APageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}