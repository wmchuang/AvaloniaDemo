using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;

namespace SqliteEFDemo.DataContext;

public class DatabaseContextFactory
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var m = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todo.xml");
        var options = new DbContextOptionsBuilder<DatabaseContext>();

        //要加密 需要引入包 SQLitePCLRaw.bundle_e_sqlcipher
        var connStr = new SqliteConnectionStringBuilder()
        {
            DataSource = m,
            Mode = SqliteOpenMode.ReadWriteCreate,
            Password = "admin"
        }.ToString();

        options.UseSqlite(connStr);
        return new DatabaseContext(options.Options);
    }

    public DatabaseContext CreateDbContext() => CreateDbContext(new string[0]);
}