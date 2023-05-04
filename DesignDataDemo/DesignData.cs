using System.Collections.ObjectModel;
using DesignDataDemo.ViewModels;

namespace DesignDataDemo;

public static class DesignData
{
    public static readonly MainWindowViewModel DesignMainWindowViewModel = new()
    {
        Greeting = "Hello Avalonia",
        List = new ObservableCollection<string>
        {
            "Hello",
            "Avalonia",
            "WPF"
        }
    };
}