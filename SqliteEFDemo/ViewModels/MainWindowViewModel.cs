using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using DynamicData;
using ReactiveUI;
using SqliteEFDemo.DataContext;
using SqliteEFDemo.Models;

namespace SqliteEFDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<TodoEntity> _todoEntities = new ObservableCollection<TodoEntity>();
    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<TodoEntity> TodoEntities
    {
        get => _todoEntities;
        set => this.RaiseAndSetIfChanged(ref _todoEntities, value);
    }

    public void Add(string thing)
    {
        using var db = new DatabaseContextFactory().CreateDbContext();
        db.TodoEntities.Add(new TodoEntity()
        {
            Id = new Guid(),
            Thing = thing,
            CreateTime = DateTime.Now
        });
        db.SaveChanges();
    }

    public void Refresh()
    {
        using var db = new DatabaseContextFactory().CreateDbContext();
        var m = db.TodoEntities.ToList();
        TodoEntities.Clear();
        TodoEntities.AddRange(m);
    }
}