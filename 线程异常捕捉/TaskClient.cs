using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace 线程异常捕捉;

public static class TaskClient
{
    public static Task Run(Func<Task> function, Action? catchDo = null)
    {
        // return Task.Run(() =>
        // {
        var task = function();
        task.Execute(catchDo);

        return task;
        // });
    }

    public static Task Run(Action action)
    {
        var task = Task.Run(action);
        task.Execute();
        return task;
    }

    private static void Execute(this Task task, Action? catchDo = null)
    {
        task.ContinueWith(t =>
        {
            t?.Exception?.Handle(ex =>
            {
                Console.WriteLine("捕获到异常");
                Console.WriteLine($"异常信息:    {ex.Message}");
                catchDo?.Invoke();
                return true;
            });
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
}