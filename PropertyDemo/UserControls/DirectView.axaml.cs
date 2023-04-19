using Avalonia;
using Avalonia.Controls;

namespace PropertyDemo.UserControls
{
    public partial class DirectView : UserControl
    {
        public DirectView ()
        {
            InitializeComponent();
        }


        #region Value Direct Avalonia Property
        private double _Value = default;

        public static readonly DirectProperty<DirectView, double> ValueProperty =
            AvaloniaProperty.RegisterDirect<DirectView, double>
            (
                nameof(Value),
                o => o.Value,
                (o, v) => o.Value = v
            );

        public double Value
        {
            get => _Value;
            set
            {
                SetAndRaise(ValueProperty, ref _Value, value);
            }
        }

        #endregion Value Direct Avalonia Property








    }
}
