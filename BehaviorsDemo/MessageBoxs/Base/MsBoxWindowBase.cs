using Avalonia.Controls;
using System.Threading.Tasks;
using Avalonia.Controls.Primitives;

namespace YlBaseUI.MessageBox.Base;

public class MsBoxWindowBase<U, T> : IMsBoxWindow<T> where U : Window, IWindowGetResult<T>
{
    private readonly U _window;

    public MsBoxWindowBase (U window)
    {
        _window = window;
    }

    /// <inheritdoc cref="IMsBoxWindow{T}"/>
    public Task<T> ShowDialog (Window ownerWindow)
    {
        var tcs = new TaskCompletionSource<T>();
        var overlayLayer = ownerWindow.Find<OverlayLayer>("PART_OverlayLayer");
        if (overlayLayer != null) overlayLayer.IsVisible = true;
        _window.Closed += delegate
        {
            if (overlayLayer != null) overlayLayer.IsVisible = false;
            tcs.TrySetResult(_window.GetResult());
        };

        _window.ShowDialog(ownerWindow);
        return tcs.Task;
    }
}