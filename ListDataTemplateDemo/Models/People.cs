using System.Collections.Generic;

namespace ListDataTemplateDemo.Models;

public class People
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Dog> Dogs { get; set; } = new();
}

public class Dog
{
    public string Name { get; set; }
}