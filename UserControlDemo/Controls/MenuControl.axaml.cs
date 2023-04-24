using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.XamlIl.Runtime;

namespace UserControlDemo.Controls;

public partial class MenuControl : UserControl
{
    public MenuControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string MenuName
    {
        get => (string)GetValue(MenuNameProperty);
        set => SetValue(MenuNameProperty, value);
    }
    

    public static readonly StyledProperty<string> MenuNameProperty = AvaloniaProperty.Register<MenuControl, string>
    (
        nameof(MenuName)
    );

    public string MenuImg
    {
        get => GetValue(MenuImgProperty);
        set => SetValue(MenuImgProperty, value);
    }

    public static readonly StyledProperty<string> MenuImgProperty = AvaloniaProperty.Register<MenuControl, string>
    (
        nameof(MenuImg)
    );

    public string MenuSelectImg
    {
        get => GetValue(MenuSelectImgProperty);
        set => SetValue(MenuSelectImgProperty, value);
    }

    public static readonly StyledProperty<string> MenuSelectImgProperty = AvaloniaProperty.Register<MenuControl, string>
    (
        nameof(MenuSelectImg)
    );

}