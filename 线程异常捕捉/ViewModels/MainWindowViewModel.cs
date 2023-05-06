using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
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
        Console.WriteLine($"主线程ID{Thread.CurrentThread.ManagedThreadId}");
        
        // TaskClient.Run(DoSomethingAsync);
        //
        // TaskClient.Run(DoSomethingAsync, () => Console.WriteLine("第二个结束"));
        
        TaskClient.Run(DoSomething);
        
        // Task.Run(async () =>
        // {
        //     await DoSomething();
        // });
        Console.WriteLine($"结束 MainWindowViewModel{DateTime.Now.ToString("mm:ss:fff")}");
    }

    public async Task DoSomethingAsync()
    {
        Console.WriteLine($"进来 DoSomethingAsync :   {DateTime.Now.ToString("mm:ss:fff")}");

        Console.WriteLine($"DoSomethingAsync 线程ID{Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(8000);
        Greeting = "Hi Avalonia";
        throw new Exception("DoSomethingAsync 抛出一个异常!");
        Console.WriteLine($"结束 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");
    }

    public void DoSomething()
    {
        Console.WriteLine($"进来 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");

        Console.WriteLine($"DoSomething 线程ID{Thread.CurrentThread.ManagedThreadId}");
        Greeting = "Hi Avalonia";
        throw new Exception("DoSomething 抛出一个异常!");
        Console.WriteLine($"结束 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");
    }

    public void DoSomething1()
    {
        Console.WriteLine($"进来 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");

        Console.WriteLine($"DoSomething 线程ID{Thread.CurrentThread.ManagedThreadId}");

        Greeting = "Hi Avalonia";
        throw new Exception(" 抛出一个异常!");
        Console.WriteLine($"结束 DoSomething{DateTime.Now.ToString("mm:ss:fff")}");
    }
}