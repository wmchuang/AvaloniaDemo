using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace 线程异常捕捉;

public static class TaskClient
{
    public static Task Run(Func<Task> function, Action? finallyDo = null)
    {
        var task = function();
        task.Execute(finallyDo);

        return task;
    }

    public static Task Run(Action action)
    {
        var task = Task.Run(action);
        task.Execute();
        return task;
    }

    private static void Execute(this Task task, Action? finallyDo = null)
    {
        task.ContinueWith(t =>
        {
            t?.Exception?.Handle(ex =>
            {
                Console.WriteLine("捕获到异常");
                Console.WriteLine($"异常信息:    {ex.Message}");
                return true;
            });
        }, TaskContinuationOptions.OnlyOnFaulted);
        if (finallyDo != null)
            task.ContinueWith(_ => finallyDo);
    }
}