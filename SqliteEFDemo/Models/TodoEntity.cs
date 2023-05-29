using System;

namespace SqliteEFDemo.Models;

public class TodoEntity
{
    public Guid Id { get; set; }

    public string Thing { get; set; }

    public DateTime CreateTime { get; set; }
}