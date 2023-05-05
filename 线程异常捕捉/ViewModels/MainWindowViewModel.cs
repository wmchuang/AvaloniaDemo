using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ReactiveUI;

namespace 线程异常捕捉.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _greeting = "Welcome to Avalonia!";

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }

    public MainWindowViewModel()
    {
        Console.WriteLine($"进来 MainWindowViewModel{DateTime.Now.ToString("mm:ss:fff")}");
        TaskClient.Run(async () =>
        {
            await DoSomething();
        });
        Console.WriteLine($"结束 MainWindowViewModel{DateTime.Now.ToString("mm:ss:fff")}");
    }

    public async Task DoSomething()
    {
        Console.WriteLine($"进来 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");
        await Task.Delay(8000);
        Greeting = "Hi Avalonia";
        throw new Exception(" 抛出一个异常!");
        Console.WriteLine($"结束 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");
    }
}