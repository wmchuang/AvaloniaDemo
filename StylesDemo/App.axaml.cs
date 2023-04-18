using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using StylesDemo.Theme;
using System.Runtime.InteropServices;

namespace StylesDemo
{
    public partial class App : Application
    {
        public override void Initialize ()
        {
            AvaloniaXamlLoader.Load(this);


            //Styles.Add(new WindowsTheme());

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Styles.Add(new MacosTheme());
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Styles.Add(new WindowsTheme());
            }
        }

        public override void OnFrameworkInitializationCompleted ()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new SelectorWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}