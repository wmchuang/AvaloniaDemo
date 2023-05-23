using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace NativeControlHostDemo;

public partial class NativeEmbedPage : UserControl
{
    public NativeEmbedPage()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public async void ShowPopupDelay(object sender, RoutedEventArgs args)
    {
        await Task.Delay(3000);
        ShowPopup(sender, args);
    }

    public void ShowPopup(object sender, RoutedEventArgs args)
    {
        new ContextMenu()
        {
            Items =
            {
                new MenuItem() { Header = "Test" }, new MenuItem() { Header = "Test" }
            }
        }.Open((Control)sender);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == BoundsProperty)
        {
            var isMobile = change.GetNewValue<Rect>().Width < 1200;
            this.Find<DockPanel>("FirstPanel")!.Classes.Set("mobile", isMobile);
            this.Find<DockPanel>("SecondPanel")!.Classes.Set("mobile", isMobile);
        }
    }
}