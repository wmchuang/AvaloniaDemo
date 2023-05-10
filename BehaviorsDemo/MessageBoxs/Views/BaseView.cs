using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace YlBaseUI.MessageBoxs.Views
{
    public class BaseView : Window
    {
        public BaseView ()
        {
            ShowInTaskbar = false;
            CanResize = false;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public async void CloseSafe ()
        {
            await Dispatcher.UIThread.InvokeAsync(Close);
        }
    }
}
