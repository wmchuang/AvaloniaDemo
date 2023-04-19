using Avalonia;
using Avalonia.Controls;

namespace PropertyDemo.UserControls
{
    public partial class StyleView : UserControl
    {
        public StyleView ()
        {
            InitializeComponent();
        }


        #region Value Styled Avalonia Property
        public double Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly StyledProperty<double> ValueProperty =
            AvaloniaProperty.Register<StyleView, double>
            (
                nameof(Value),
                7.0
            );
        #endregion Value Styled Avalonia Property

    }
}
