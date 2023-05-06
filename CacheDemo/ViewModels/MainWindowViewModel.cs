using System;
using Microsoft.Extensions.Caching.Memory;
using ReactiveUI.Fody.Helpers;

namespace CacheDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly string cacheKey = "myKey";

    [Reactive] public string CacheData { get; set; }

    public void SetCache(string data)
    {
        CacheClient.Current.Set(cacheKey, data);
    }

    public void GetCache()
    {
        var m = CacheClient.Current.Get<string>(cacheKey);
        Console.WriteLine(m ?? "没有值");
    }
}