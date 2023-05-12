using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;

namespace ScrollViewerDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    
    public ObservableCollection<string> List { get; set; }

    public MainWindowViewModel()
    {
        List = new ObservableCollection<string>();
        
        List.AddRange(Enumerable.Range(1,20).Select(x => $"Hello {x}"));
    }

    public void Load()
    {
        List.AddRange(Enumerable.Range(1,10).Select(x => $"New {x}"));
    }
}