using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using ReactiveUI;

namespace BehaviorsDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Green_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var msgBoxView = new TestView();
        msgBoxView.ShowDialog(this);
    }
}