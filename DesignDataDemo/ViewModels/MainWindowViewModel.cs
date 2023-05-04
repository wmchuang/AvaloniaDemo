using System.Collections.ObjectModel;

namespace DesignDataDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; set; }

    public ObservableCollection<string> List { get; set; }
}