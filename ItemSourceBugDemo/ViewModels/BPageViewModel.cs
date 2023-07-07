using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI.Fody.Helpers;

namespace ItemSourceBugDemo.ViewModels;

public class TestModel
{
    public string Name { get; set; }
    public string Name1 { get; set; }
    public string Name2 { get; set; }
    public string Name3 { get; set; }
    public string Name4 { get; set; }
    public string Name5 { get; set; }
    public string Name6 { get; set; }
    public string Name7 { get; set; }
    public string Name8 { get; set; }
    public string Name9 { get; set; }
    public string Name10 { get; set; }
    public string Name11{ get; set; }
    public string Name12 { get; set; }
    public string Name13 { get; set; }
}

public class BPageViewModel  : ViewModelBase
{
    public BPageViewModel()
    {
        Task.Run(() => { Init(); });
    }

    [Reactive]
    public ObservableCollection<TestModel> ListData { get; set; } = new();
    
    /// <summary>
    /// 是否正在请求下一页数据中
    /// </summary>
    private bool IsNextLoading { get; set; }


    public Task Init()
    {
        ListData.Clear();
        ListData.AddRange(Enumerable.Range(1, 50).Select(x =>
            new TestModel
            {
                Name = $"Hello {x}",
                Name1 = $"Hello {x}",
                Name2 = $"Hello {x}",
                Name3 = $"Hello {x}",
                Name4 = $"Hello {x}",
                Name5 = $"Hello {x}",
                Name6 = $"Hello {x}",
                Name7 = $"Hello {x}",
                Name8 = $"Hello {x}",
                Name9 = $"Hello {x}",
                Name10 = $"Hello {x}",
                Name11 = $"Hello {x}",
            }
        ));
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// 加载下一页
    /// </summary>
    public void LoadNextPageData()
    {
        if (IsNextLoading)
            return;

        IsNextLoading = true;
        _ = Task.Run(() =>
        {
            var list = Enumerable.Range(1, 30).Select(x =>
                new TestModel
                {
                    Name = $"Hello Next {x}"
                }
            );
            ListData.AddRange(list);
            IsNextLoading = false;
            return Task.CompletedTask;
        });
    }
}