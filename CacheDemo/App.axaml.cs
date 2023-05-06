using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CacheDemo.ViewModels;
using CacheDemo.Views;

namespace CacheDemo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            
            desktop.MainWindow = new MainWindow
            {
              
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
    }
}