using System.Threading;
using System.Threading.Tasks;

namespace LoggerDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public MainWindowViewModel()
    {
        for (int i = 0; i < 10; i++)
        {
            Task.Run(() =>
            { 
                LoggerClient.Info($"日志记录 线程Id: {Thread.CurrentThread.ManagedThreadId}");
                LoggerClient.Error($"日志记录 线程Id: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
        // LoggerClient.Instance.Warn("test");
        // LoggerClient.Instance.Error("test");
    }
}