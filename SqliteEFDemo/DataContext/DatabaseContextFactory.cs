using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SqliteEFDemo.DataContext;

public class DatabaseContextFactory
{
    public DatabaseContext CreateDbContext(string[] args)
    {

        var m = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todo.db");
        var options = new DbContextOptionsBuilder<DatabaseContext>();
        options.UseSqlite($"Data Source={m};");
        return new DatabaseContext(options.Options);
    }

    public DatabaseContext CreateDbContext() => CreateDbContext(new string[0]);
}