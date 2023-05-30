using System.Collections.Generic;
using System.Collections.ObjectModel;
using ListDataTemplateDemo.Models;

namespace ListDataTemplateDemo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// As this is a list of Persons, we can add Students and Teachers here. 
    /// </summary>
    public List<People> People { get; } = new List<People>()
    {
        new People
        {
            FirstName = "Mr.",
            LastName = "X",
        },
        new People
        {
            FirstName = "Hello",
            LastName = "World",
        },
        new People
        {
            FirstName = "Hello",
            LastName = "Kitty",
        }
    };
}