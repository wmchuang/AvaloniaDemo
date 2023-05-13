using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using IocDemo.Services;
using IocDemo.ViewModels;
using IocDemo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace IocDemo;

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
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<ILogger, Logger>();
        
        var provider = serviceCollection.BuildServiceProvider();
        var logger = provider.GetService<ILogger>();
        logger.Debug();
        base.RegisterServices();
    }
}