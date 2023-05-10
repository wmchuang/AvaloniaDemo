using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BehaviorsDemo.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YlBaseUI;
using YlBaseUI.MessageBoxs;

namespace BehaviorsDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static int count = 0;

    [Reactive] public string Greeting { get; set; } = "Welcome to Avalonia!";

    public ReactiveCommand<Unit, Unit> Red
    {
        get
        {
            return ReactiveCommand.Create(() =>
            {
                count += 1;
                Greeting = "你点击了红色" + count;
            });
        }
    }

    public ReactiveCommand<Unit, Unit> Green
    {
        get
        {
            return ReactiveCommand.CreateFromTask(() =>
            {
                return Task.Run(async () =>
                {
                    try
                    {
                        var window = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime)
                            .Windows.FirstOrDefault(x => x.GetType() == typeof(MainWindow));
                        await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(async () =>
                        {
                            var result = await NMessageBox.ShowDialog(window, "确定执行当前的操作吗？");
                            Greeting = result.ToString();
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                });
            });
        }
    }
}