using System;

namespace IocDemo.Services;

public class Logger : ILogger
{
    public Logger()
    {
        Console.WriteLine("Logger Ctor");
    }
    public void Debug()
    {
        Console.WriteLine("Debug");
    }
}