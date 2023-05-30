using DataTemplateDemo.Models;
using ReactiveUI;

namespace DataTemplateDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private People _people = new People()
    {
        FirstName = "Ma",
        LastName = "Yun"
    };
    public string Greeting => "Welcome to Avalonia!";

    public People People
    {
        get => _people;
        set => this.RaiseAndSetIfChanged(ref _people, value);
    }
}