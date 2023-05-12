using Avalonia;
using Avalonia.Controls;

namespace PropertyDemo.UserControls;

public class AttachedProperties
{
    public static string GetValue(AvaloniaObject obj)
    {
        return obj.GetValue(ValueProperty);
    }

    public static void SetValue(AvaloniaObject obj, string value)
    {
        obj.SetValue(ValueProperty, value);
    }

    public static readonly AttachedProperty<string> ValueProperty =
        AvaloniaProperty.RegisterAttached<AttachedProperties, IControl, string>
        (
            "Value"
        );
}