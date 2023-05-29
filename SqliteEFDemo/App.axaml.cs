using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SqliteEFDemo.DataContext;
using SqliteEFDemo.ViewModels;
using SqliteEFDemo.Views;

namespace SqliteEFDemo;

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
        using var db = new DatabaseContextFactory().CreateDbContext();
        db.Database.EnsureCreated();
    }
}