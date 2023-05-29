using Microsoft.EntityFrameworkCore;
using SqliteEFDemo.Models;

namespace SqliteEFDemo.DataContext;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    
    public DbSet<TodoEntity> TodoEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<TodoEntity>(m =>
        {
            m.ToTable("todo");
            m.Property(c => c.Id);
            m.Property(c => c.Thing).IsRequired();
            m.HasKey(c => c.Id);
        });
    }
}