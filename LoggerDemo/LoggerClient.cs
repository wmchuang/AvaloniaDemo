using System;
using NLog;

namespace LoggerDemo;

public static class LoggerClient
{
    private static ILogger Current;

    static LoggerClient()
    {
        var config = new NLog.Config.LoggingConfiguration();

        var logfile = new NLog.Targets.FileTarget("logfile")
        {
            FileName = $"logs/{DateTime.Now.ToString("yyyy-MM-dd")}.txt"
        };
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        LogManager.Configuration = config;
       
        var logger = LogManager.GetCurrentClassLogger();
        Console.WriteLine("初始化");

        Current = logger;
    }
  
    public static void Error(string data)
    {
        Current.Error(data);
    }

    public static void Warn(string data)
    {
        Current.Warn(data);
    }

    public static void Info(string data)
    {
        Current.Info(data);
    }
}