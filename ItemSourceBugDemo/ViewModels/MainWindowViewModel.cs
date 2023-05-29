using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI.Fody.Helpers;

namespace ItemSourceBugDemo.ViewModels;



public class MainWindowViewModel : ViewModelBase
{
    [Reactive] public ViewModelBase CurrentPage { get; set; } = new APageViewModel();
}