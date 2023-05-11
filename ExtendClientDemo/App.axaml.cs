using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExtendClientDemo.ViewModels;
using ExtendClientDemo.Views;

namespace ExtendClientDemo;

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
            desktop.Startup += DesktopOnStartup;
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    /// <summary>
    /// 客户端启动日志
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void DesktopOnStartup(object sender, ControlledApplicationLifetimeStartupEventArgs e)
    {
        Console.WriteLine($"启动 时间{DateTime.Now.ToString("mm:ss:fff")}");
        Console.WriteLine("客户端启动了");
        
       
    }
}