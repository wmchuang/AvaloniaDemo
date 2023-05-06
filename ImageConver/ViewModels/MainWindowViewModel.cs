using System.Collections.ObjectModel;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;

namespace ImageConver.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "avares://ImageConver/Assets/DSC_1338.jpg";

    [Reactive] public ObservableCollection<string> List { get; set; } = new ObservableCollection<string>();

    public MainWindowViewModel()
    {
        //List.Add(Greeting);
    }

    public void Add()
    {
        List.Add(Greeting);
    }
}