using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AotDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    // private string _firstName = "Aot";
    //
    // public string FirstName
    // {
    //     get => _firstName;
    //     set => this.RaiseAndSetIfChanged(ref _firstName, value);
    // }

    [Reactive] public string FirstName { get; set; } = "Aot";

    public ReactiveCommand<Unit, Unit> ButtonCommand => ReactiveCommand.CreateFromTask<Unit>(_ =>
    {
        FirstName = "Bye";
        
        return Task.FromResult(Unit.Default);
    });
}