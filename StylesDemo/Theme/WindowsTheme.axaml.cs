using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StylesDemo.Theme
{
    public class WindowsTheme : Styles
    {
        public WindowsTheme ()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
