using Avalonia;
using Avalonia.Controls.Primitives;

namespace TemplatedControlDemo.Controls;

public class MenuControl : TemplatedControl
{
    public string MenuName
    {
        get => GetValue(propertyNameProperty);
        set => SetValue(propertyNameProperty, value);
    }

    public static readonly StyledProperty<string> propertyNameProperty = AvaloniaProperty.Register<MenuControl, string>
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

}