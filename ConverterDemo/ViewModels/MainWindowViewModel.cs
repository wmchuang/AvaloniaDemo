using System.Net;
using ReactiveUI;

namespace ConverterDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private IPAddress _ip;

    public IPAddress IP
    {
        get => _ip;
        set => this.RaiseAndSetIfChanged(ref _ip, value);
    }
}