using Avalonia;
using Avalonia.Controls;

namespace PropertyDemo.UserControls
{
    public partial class AttachView : UserControl
    {
        public AttachView ()
        {
            InitializeComponent();
        }


        #region Value Attached Avalonia Property
        public static double GetValue (AvaloniaObject obj)
        {
            return obj.GetValue(ValueProperty);
        }

        public static void SetValue (AvaloniaObject obj, double value)
        {
            obj.SetValue(ValueProperty, value);
        }

        public static readonly AttachedProperty<double> ValueProperty =
            AvaloniaProperty.RegisterAttached<object, IControl, double>
            (
                "Value"
            );
        #endregion

    }
}
